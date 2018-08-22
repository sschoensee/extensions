﻿import * as React from 'react'
import { Lite, Entity, liteKey } from '@framework/Signum.Entities'
import { getQueryKey, getQueryNiceName } from '@framework/Reflection'
import { OmniboxMessage } from '../Omnibox/Signum.Entities.Omnibox'
import { OmniboxResult, OmniboxMatch, OmniboxProvider } from '../Omnibox/OmniboxClient'
import { QueryToken, FilterOperation, FindOptions, FilterOption } from '@framework/FindOptions'
import * as Navigator from '@framework/Navigator'
import * as Finder from '@framework/Finder'
import * as DashboardClient from './DashboardClient'
import { DashboardEntity } from './Signum.Entities.Dashboard'

export default class DashboardOmniboxProvider extends OmniboxProvider<DashboardOmniboxResult>
{
    getProviderName() {
        return "DashboardOmniboxResult";
    }

    icon() {
        return this.coloredIcon("tachometer-alt", "darkslateblue");
    }

    renderItem(result: DashboardOmniboxResult): React.ReactChild[] {

        const array: React.ReactChild[] = [];

        array.push(this.icon());

        this.renderMatch(result.toStrMatch, array);

        return array;
    }

    navigateTo(result: DashboardOmniboxResult) {

        if (result.dashboard == undefined)
            return undefined;

        return Promise.resolve(DashboardClient.dashboardUrl(result.dashboard));
    }

    toString(result: DashboardOmniboxResult) {
        return "\"{0}\"".formatWith(result.toStrMatch.text);
    }
}

interface DashboardOmniboxResult extends OmniboxResult {
    toStr: string;
    toStrMatch: OmniboxMatch;
    
    dashboard: Lite<DashboardEntity>;
}
