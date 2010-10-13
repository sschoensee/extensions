﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Signum.Utilities;
using Signum.Utilities.ExpressionTrees;
using Signum.Entities.Operations;
using Signum.Engine.Maps;
using System.Threading;
using Signum.Entities.Authorization;
using Signum.Entities;
using System.Diagnostics;
using Signum.Engine.SchemaInfoTables;
using Signum.Engine.Authorization;
using Signum.Utilities.Reflection;
using Signum.Utilities.DataStructures;
using Signum.Engine.Extensions.Properties;
using System.Xml.Linq;
using System.ComponentModel;

namespace Signum.Engine.Operations
{
    public class Graph<E, S>
        where E : IdentifiableEntity
        where S : struct
    {
        public interface IGraphOperation : IOperation
        {
            Graph<E, S> Graph { get;set; } 
        }

        public interface IGraphInnerOperation : IGraphOperation
        { 
            S TargetState { get; }
        }

        public class Goto : BasicExecute<E>, IGraphInnerOperation
        {
            public Graph<E, S> Graph { get; set; } 
            public S TargetState { get; private set; }
            public S[] FromStates { get; set; }

            public Goto(Enum key, S targetState) : base(key)
            {
                this.TargetState = targetState;
            }

            protected override string OnCanExecute(E entity)
            {
                S state = Graph.GetState(entity);
                if (FromStates != null && !FromStates.Contains(state))
                    return Resources.ImpossibleToExecute0FromState1.Formato(Key, state); 

                return base.OnCanExecute(entity);
            }

            protected override void OnExecute(E entity, object[] args)
            {
                S oldState = Graph.GetState(entity);

                Graph.OnExitState(oldState, entity);

                base.OnExecute(entity, args);

                Graph.AssertEnterState(entity, this);
            }
        }

        public class Delete : BasicDelete<E>, IGraphOperation
        {
            public Graph<E, S> Graph { get; set; }
            public S[] FromStates { get; set; }

            public Delete(Enum key) : base(key)
            {

            }

            protected override string OnCanDelete(E entity)
            {
                S state = Graph.GetState(entity);
                if (FromStates != null && !FromStates.Contains(state))
                    return Resources.ImpossibleToExecute0FromState1.Formato(Key, state);

                return base.OnCanDelete(entity);
            }

            protected override void OnDelete(E entity, object[] args)
            {
                S oldState = Graph.GetState(entity);

                Graph.OnExitState(oldState, entity);

                base.OnDelete(entity, args);
            }
        }

        public class Construct : BasicConstructor<E>, IGraphInnerOperation
        {
            public Graph<E, S> Graph { get; set; }
            public S TargetState { get; private set; }

            public Construct(Enum key, S targetState)
                : base(key)
            {
                this.TargetState = targetState;
            }

            protected override E OnConstruct(object[] args)
            {
                E result = base.OnConstruct(args);

                Graph.AssertEnterState(result, this);

                return result;
            }

            public override string ToString()
            {
                return base.ToString() + " in state " + TargetState;
            }
        }

        public class ConstructFrom<F> : BasicConstructorFrom<F, E>, IGraphInnerOperation
            where F : class, IIdentifiable
        {
            public Graph<E, S> Graph { get; set; }
            public S TargetState { get; private set; }

            public ConstructFrom(Enum key, S targetState)
                : base(key)
            {
                this.TargetState = targetState;
            }

            protected override E OnConstruct(F entity, object[] args)
            {
                E result = base.OnConstruct(entity, args);

                Graph.AssertEnterState(result, this);

                return result;
            }

            public override string ToString()
            {
                return base.ToString() + " in state " + TargetState;
            }
        }

        public class ConstructFromMany<F> : BasicConstructorFromMany<F, E>, IGraphInnerOperation
            where F : class, IIdentifiable
        {
            public Graph<E, S> Graph { get; set; }
            public S TargetState { get; private set; }

            public ConstructFromMany(Enum key, S targetState)
                : base(key)
            {
                this.TargetState = targetState;
            }

            protected override E OnConstructor(List<Lite<F>> lites, object[] args)
            {
                E result = base.OnConstructor(lites, args);

                Graph.AssertEnterState(result, this);

                return result;
            }

            public override string ToString()
            {
                return base.ToString() + " in state " + TargetState;
            }
        }

        public class StateOptions
        {
            public Action<E> Enter { get; set; }
            public Action<E> Exit { get; set; }
        }

        protected Func<E, S> GetState { get; set; }

        protected Action<E, S> EnterState { get; set; }
        protected Action<E, S> ExitState { get; set; }

        protected List<IGraphOperation> Operations { get; set; }
        protected Dictionary<S, StateOptions> States { get; set; }


        public virtual void Register()
        {
            var errors = Operations.GroupCount(a => a.Key).Where(kvp => kvp.Value > 1).ToList();

            if (errors.Count != 0)
                throw new InvalidOperationException(Resources.TheFollowingKeysHaveBeenRepeatedIn01.Formato(GetType(), errors.ToString(a => " - {0} ({1})".Formato(a.Key, a.Value), "\r\n")));

            foreach (var operation in Operations)
	        {
                operation.Graph = this;

                OperationLogic.Register(operation);
	        }
        }

       

        public DirectedEdgedGraph<string, string> ToDirectedGraph()
        {

            DirectedEdgedGraph<string, string> result = new DirectedEdgedGraph<string, string>();

            Action<string, string, Enum> Add = (from, to, key) =>
                {
                    Dictionary<string, string> dic = result.TryRelatedTo(from);
                    if (dic == null || !dic.ContainsKey(to))
                        result.Add(from, to, key.ToString());
                    else
                        result.Add(from, to, dic[to] + ", " + key.ToString()); 
                }; 
            
            foreach (var item in Operations)
            {
                switch (item.OperationType)
                {
                    case OperationType.Execute:
                        {
                            Goto gOp = (Goto)item;

                            if (gOp.FromStates == null)
                                Add("[All States]", gOp.TargetState.ToString(), item.Key);
                            else
                                foreach (var s in gOp.FromStates)
                                    Add(s.ToString(), gOp.TargetState.ToString(), item.Key);


                        } break;
                    case OperationType.Delete:
                        {
                            Delete dOp = (Delete)item;
                            if (dOp.FromStates == null)
                                Add("[All States]", "[Deleted]", item.Key);
                            else
                                foreach (var s in dOp.FromStates)
                                    Add(s.ToString(), "[Deleted]", dOp.Key);


                        } break;
                    case OperationType.Constructor:
                    case OperationType.ConstructorFrom:
                    case OperationType.ConstructorFromMany:
                        {
                            string from = item.OperationType == OperationType.Constructor ? "[New]" :
                                          item.OperationType == OperationType.ConstructorFrom ? "[From {0}]".Formato(item.GetType().GetGenericArguments()[2].TypeName()) :
                                          item.OperationType == OperationType.ConstructorFromMany ? "[FromMany {0}]".Formato(item.GetType().GetGenericArguments()[2].TypeName()) : "";

                            Add(from, ((IGraphInnerOperation)item).TargetState.ToString(), item.Key);


                        } break;
                }
            }

            return result;
        }

        internal void OnExitState(S state, E entity)
        {
            StateOptions so = States.TryGetC(state);
            if (so != null && so.Exit != null)
                so.Exit(entity);

            if (ExitState != null)
                ExitState(entity, state);
        }

        internal void OnEnterState(S state, E entity)
        {
            if (EnterState != null)
                EnterState(entity, state);

            StateOptions sn = States.TryGetC(state);
            if (sn != null && sn.Enter != null)
                sn.Enter(entity);
        }

        internal void AssertEnterState(E entity, IGraphInnerOperation operation)
        {
            S state = GetState(entity);

            if (!state.Equals(operation.TargetState))
                throw new InvalidOperationException(Resources.AfterTheOperationTheStateShouldBe0ButIs1.Formato(operation.Key ,operation.TargetState, state));

            OnEnterState(state, entity);
        }
    }
}
