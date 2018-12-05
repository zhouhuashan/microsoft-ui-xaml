// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

// DO NOT EDIT! This file was generated by CustomTasks.DependencyPropertyCodeGen
#pragma once

class ScrollerViewProperties
{
public:
    ScrollerViewProperties();

    void ComputedHorizontalScrollMode(winrt::ScrollerScrollMode const& value);
    winrt::ScrollerScrollMode ComputedHorizontalScrollMode();

    void ComputedVerticalScrollMode(winrt::ScrollerScrollMode const& value);
    winrt::ScrollerScrollMode ComputedVerticalScrollMode();

    void Content(winrt::UIElement const& value);
    winrt::UIElement Content();

    void HorizontalAnchorRatio(double value);
    double HorizontalAnchorRatio();

    void HorizontalScrollChainingMode(winrt::ScrollerChainingMode const& value);
    winrt::ScrollerChainingMode HorizontalScrollChainingMode();

    void HorizontalScrollController(winrt::IScrollController const& value);
    winrt::IScrollController HorizontalScrollController();

    void HorizontalScrollControllerVisibility(winrt::ScrollerViewScrollControllerVisibility const& value);
    winrt::ScrollerViewScrollControllerVisibility HorizontalScrollControllerVisibility();

    void HorizontalScrollMode(winrt::ScrollerScrollMode const& value);
    winrt::ScrollerScrollMode HorizontalScrollMode();

    void HorizontalScrollRailingMode(winrt::ScrollerRailingMode const& value);
    winrt::ScrollerRailingMode HorizontalScrollRailingMode();

    void InputKind(winrt::ScrollerInputKind const& value);
    winrt::ScrollerInputKind InputKind();

    void IsAnchoredAtHorizontalExtent(bool value);
    bool IsAnchoredAtHorizontalExtent();

    void IsAnchoredAtVerticalExtent(bool value);
    bool IsAnchoredAtVerticalExtent();

    void IsChildAvailableHeightConstrained(bool value);
    bool IsChildAvailableHeightConstrained();

    void IsChildAvailableWidthConstrained(bool value);
    bool IsChildAvailableWidthConstrained();

    void MaxZoomFactor(double value);
    double MaxZoomFactor();

    void MinZoomFactor(double value);
    double MinZoomFactor();

    void VerticalAnchorRatio(double value);
    double VerticalAnchorRatio();

    void VerticalScrollChainingMode(winrt::ScrollerChainingMode const& value);
    winrt::ScrollerChainingMode VerticalScrollChainingMode();

    void VerticalScrollController(winrt::IScrollController const& value);
    winrt::IScrollController VerticalScrollController();

    void VerticalScrollControllerVisibility(winrt::ScrollerViewScrollControllerVisibility const& value);
    winrt::ScrollerViewScrollControllerVisibility VerticalScrollControllerVisibility();

    void VerticalScrollMode(winrt::ScrollerScrollMode const& value);
    winrt::ScrollerScrollMode VerticalScrollMode();

    void VerticalScrollRailingMode(winrt::ScrollerRailingMode const& value);
    winrt::ScrollerRailingMode VerticalScrollRailingMode();

    void ZoomChainingMode(winrt::ScrollerChainingMode const& value);
    winrt::ScrollerChainingMode ZoomChainingMode();

    void ZoomMode(winrt::ScrollerZoomMode const& value);
    winrt::ScrollerZoomMode ZoomMode();

    static winrt::DependencyProperty ComputedHorizontalScrollModeProperty() { return s_ComputedHorizontalScrollModeProperty; }
    static winrt::DependencyProperty ComputedVerticalScrollModeProperty() { return s_ComputedVerticalScrollModeProperty; }
    static winrt::DependencyProperty ContentProperty() { return s_ContentProperty; }
    static winrt::DependencyProperty HorizontalAnchorRatioProperty() { return s_HorizontalAnchorRatioProperty; }
    static winrt::DependencyProperty HorizontalScrollChainingModeProperty() { return s_HorizontalScrollChainingModeProperty; }
    static winrt::DependencyProperty HorizontalScrollControllerProperty() { return s_HorizontalScrollControllerProperty; }
    static winrt::DependencyProperty HorizontalScrollControllerVisibilityProperty() { return s_HorizontalScrollControllerVisibilityProperty; }
    static winrt::DependencyProperty HorizontalScrollModeProperty() { return s_HorizontalScrollModeProperty; }
    static winrt::DependencyProperty HorizontalScrollRailingModeProperty() { return s_HorizontalScrollRailingModeProperty; }
    static winrt::DependencyProperty InputKindProperty() { return s_InputKindProperty; }
    static winrt::DependencyProperty IsAnchoredAtHorizontalExtentProperty() { return s_IsAnchoredAtHorizontalExtentProperty; }
    static winrt::DependencyProperty IsAnchoredAtVerticalExtentProperty() { return s_IsAnchoredAtVerticalExtentProperty; }
    static winrt::DependencyProperty IsChildAvailableHeightConstrainedProperty() { return s_IsChildAvailableHeightConstrainedProperty; }
    static winrt::DependencyProperty IsChildAvailableWidthConstrainedProperty() { return s_IsChildAvailableWidthConstrainedProperty; }
    static winrt::DependencyProperty MaxZoomFactorProperty() { return s_MaxZoomFactorProperty; }
    static winrt::DependencyProperty MinZoomFactorProperty() { return s_MinZoomFactorProperty; }
    static winrt::DependencyProperty ScrollerProperty() { return s_ScrollerProperty; }
    static winrt::DependencyProperty VerticalAnchorRatioProperty() { return s_VerticalAnchorRatioProperty; }
    static winrt::DependencyProperty VerticalScrollChainingModeProperty() { return s_VerticalScrollChainingModeProperty; }
    static winrt::DependencyProperty VerticalScrollControllerProperty() { return s_VerticalScrollControllerProperty; }
    static winrt::DependencyProperty VerticalScrollControllerVisibilityProperty() { return s_VerticalScrollControllerVisibilityProperty; }
    static winrt::DependencyProperty VerticalScrollModeProperty() { return s_VerticalScrollModeProperty; }
    static winrt::DependencyProperty VerticalScrollRailingModeProperty() { return s_VerticalScrollRailingModeProperty; }
    static winrt::DependencyProperty ZoomChainingModeProperty() { return s_ZoomChainingModeProperty; }
    static winrt::DependencyProperty ZoomModeProperty() { return s_ZoomModeProperty; }

    static GlobalDependencyProperty s_ComputedHorizontalScrollModeProperty;
    static GlobalDependencyProperty s_ComputedVerticalScrollModeProperty;
    static GlobalDependencyProperty s_ContentProperty;
    static GlobalDependencyProperty s_HorizontalAnchorRatioProperty;
    static GlobalDependencyProperty s_HorizontalScrollChainingModeProperty;
    static GlobalDependencyProperty s_HorizontalScrollControllerProperty;
    static GlobalDependencyProperty s_HorizontalScrollControllerVisibilityProperty;
    static GlobalDependencyProperty s_HorizontalScrollModeProperty;
    static GlobalDependencyProperty s_HorizontalScrollRailingModeProperty;
    static GlobalDependencyProperty s_InputKindProperty;
    static GlobalDependencyProperty s_IsAnchoredAtHorizontalExtentProperty;
    static GlobalDependencyProperty s_IsAnchoredAtVerticalExtentProperty;
    static GlobalDependencyProperty s_IsChildAvailableHeightConstrainedProperty;
    static GlobalDependencyProperty s_IsChildAvailableWidthConstrainedProperty;
    static GlobalDependencyProperty s_MaxZoomFactorProperty;
    static GlobalDependencyProperty s_MinZoomFactorProperty;
    static GlobalDependencyProperty s_ScrollerProperty;
    static GlobalDependencyProperty s_VerticalAnchorRatioProperty;
    static GlobalDependencyProperty s_VerticalScrollChainingModeProperty;
    static GlobalDependencyProperty s_VerticalScrollControllerProperty;
    static GlobalDependencyProperty s_VerticalScrollControllerVisibilityProperty;
    static GlobalDependencyProperty s_VerticalScrollModeProperty;
    static GlobalDependencyProperty s_VerticalScrollRailingModeProperty;
    static GlobalDependencyProperty s_ZoomChainingModeProperty;
    static GlobalDependencyProperty s_ZoomModeProperty;

    winrt::event_token AnchorRequested(winrt::TypedEventHandler<winrt::ScrollerView, winrt::ScrollerAnchorRequestedEventArgs> const& value);
    void AnchorRequested(winrt::event_token const& token);
    winrt::event_token BringingIntoView(winrt::TypedEventHandler<winrt::ScrollerView, winrt::ScrollerBringingIntoViewEventArgs> const& value);
    void BringingIntoView(winrt::event_token const& token);
    winrt::event_token ChangingOffsets(winrt::TypedEventHandler<winrt::ScrollerView, winrt::ScrollerChangingOffsetsEventArgs> const& value);
    void ChangingOffsets(winrt::event_token const& token);
    winrt::event_token ChangingZoomFactor(winrt::TypedEventHandler<winrt::ScrollerView, winrt::ScrollerChangingZoomFactorEventArgs> const& value);
    void ChangingZoomFactor(winrt::event_token const& token);
    winrt::event_token ExtentChanged(winrt::TypedEventHandler<winrt::ScrollerView, winrt::IInspectable> const& value);
    void ExtentChanged(winrt::event_token const& token);
    winrt::event_token StateChanged(winrt::TypedEventHandler<winrt::ScrollerView, winrt::IInspectable> const& value);
    void StateChanged(winrt::event_token const& token);
    winrt::event_token ViewChangeCompleted(winrt::TypedEventHandler<winrt::ScrollerView, winrt::ScrollerViewChangeCompletedEventArgs> const& value);
    void ViewChangeCompleted(winrt::event_token const& token);
    winrt::event_token ViewChanged(winrt::TypedEventHandler<winrt::ScrollerView, winrt::IInspectable> const& value);
    void ViewChanged(winrt::event_token const& token);

    event_source<winrt::TypedEventHandler<winrt::ScrollerView, winrt::ScrollerAnchorRequestedEventArgs>> m_anchorRequestedEventSource;
    event_source<winrt::TypedEventHandler<winrt::ScrollerView, winrt::ScrollerBringingIntoViewEventArgs>> m_bringingIntoViewEventSource;
    event_source<winrt::TypedEventHandler<winrt::ScrollerView, winrt::ScrollerChangingOffsetsEventArgs>> m_changingOffsetsEventSource;
    event_source<winrt::TypedEventHandler<winrt::ScrollerView, winrt::ScrollerChangingZoomFactorEventArgs>> m_changingZoomFactorEventSource;
    event_source<winrt::TypedEventHandler<winrt::ScrollerView, winrt::IInspectable>> m_extentChangedEventSource;
    event_source<winrt::TypedEventHandler<winrt::ScrollerView, winrt::IInspectable>> m_stateChangedEventSource;
    event_source<winrt::TypedEventHandler<winrt::ScrollerView, winrt::ScrollerViewChangeCompletedEventArgs>> m_viewChangeCompletedEventSource;
    event_source<winrt::TypedEventHandler<winrt::ScrollerView, winrt::IInspectable>> m_viewChangedEventSource;

    static void EnsureProperties();
    static void ClearProperties();

    static void OnPropertyChanged(
        winrt::DependencyObject const& sender,
        winrt::DependencyPropertyChangedEventArgs const& args);

    static void OnPropertyChanged_ValidateAnchorRatio(
        winrt::DependencyObject const& sender,
        winrt::DependencyPropertyChangedEventArgs const& args);

    static void OnPropertyChanged_ValidateZoomFactoryBoundary(
        winrt::DependencyObject const& sender,
        winrt::DependencyPropertyChangedEventArgs const& args);
};