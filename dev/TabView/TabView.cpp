// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#include "pch.h"
#include "common.h"
#include "TabView.h"
#include "RuntimeProfiler.h"
#include "ResourceAccessor.h"

TabView::TabView()
{
    __RP_Marker_ClassById(RuntimeProfiler::ProfId_TabView);

    SetDefaultStyleKey(this);
}

void TabView::OnApplyTemplate()
{
    winrt::IControlProtected controlProtected{ *this };

    // TODO: Implement
}

void  TabView::OnPropertyChanged(const winrt::DependencyPropertyChangedEventArgs& args)
{
    winrt::IDependencyProperty property = args.Property();
    
    // TODO: Implement
}
