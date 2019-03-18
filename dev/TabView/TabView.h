// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#pragma once

#include "pch.h"
#include "common.h"

#include "TabView.g.h"
#include "TabView.properties.h"

class TabView :
    public ReferenceTracker<TabView, winrt::implementation::TabViewT>,
    public TabViewProperties
{

public:
    TabView();
    ~TabView() {}

    // IFrameworkElement
    void OnApplyTemplate();

    void OnPropertyChanged(const winrt::DependencyPropertyChangedEventArgs& args);
};
