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

private ButtonWidget _button1Widget = new ButtonWidget()
{
    Label = "Button 1"
};

private ButtonWidget _button2Widget = new ButtonWidget()
{
    Label = "Button 2"
};

private void OnEnable()
{
    _button1Widget.Clicked = OnButton1Clicked;
    _button2Widget.Clicked = OnButton2Clicked;
    _rootGroup = new VerticalElementGroup(
        _toggleWidget,
        new HorizontalElementGroup(
            _button1Widget,
            _button2Widget
        )
    );
}

private void OnGUI()
{
    _rootGroup.Draw();
}

private void OnButton1Clicked()
{
    Debug.Log("Clicked 1!");
}

private void OnButton2Clicked()
{
    Debug.Log("Clicked 2!");
}
```
