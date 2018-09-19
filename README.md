# RETGUI
A simple lightweight stateful wrapper library around Unity's IMGUI.

## How to Use
First define a root element group, typically vertical:
```csharp
private VerticalElementGroup _rootGroup;
```

Then start adding widgets, then draw the root:
```csharp
private VerticalElementGroup _rootGroup;

private ToggleWidget _toggleWidget = new ToggleWidget()
{
    Label = "A Toggle"
};

private void OnEnable()
{
    _rootGroup = new VerticalElementGroup(
        _toggleWidget
    );
}

private void OnGUI()
{
    _rootGroup.Draw();
}
```
You can add multiple elements to a group, including other groups:
```csharp
private VerticalElementGroup _rootGroup;

private ToggleWidget _toggleWidget = new ToggleWidget()
{
    Label = "A Toggle"
};

private ButtonWidget _buttonWidget = new ButtonWidget()
{
    Label = "Button 1"
};

private IntSliderWidget _intSlider = new IntSliderWidget()
{
    Label = "Int Value",
    MinValue = 5,
    MaxValue = 50
};

private void OnEnable()
{
    _buttonWidget.Clicked = OnButtonClicked;
    _rootGroup = new VerticalElementGroup(
        _toggleWidget,
        new HorizontalElementGroup(
            _buttonWidget,
            _intSlider
        )
    );
}

private void OnGUI()
{
    _rootGroup.Draw();
}

private void OnButtonClicked()
{
    // Implicit value retrieval
    Debug.Log($"Int slider squared equals: {_intSlider * _intSlider}");
}
```
