using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;
using System.Windows.Media;

namespace TpQuestionnaireManager.Behaviors;

public class RequiredBehavior : Behavior<TextBox>
{
    private bool hasUserInput = false;

    protected override void OnAttached()
    {
        base.OnAttached();
        var txtBox = this.AssociatedObject as TextBox;
        txtBox.TextChanged += this.OnTextChanged;
    }

    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var txtBox = this.AssociatedObject as TextBox;
        hasUserInput = true;
        this.SetBackgroundColor(txtBox);
    }

    private void SetBackgroundColor(TextBox txtBox)
    {
        if (!hasUserInput)
        {
            txtBox.BorderBrush = new SolidColorBrush(Colors.Gray);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtBox.Text) || txtBox.Text.Length < 5)
        {
            txtBox.BorderBrush = new SolidColorBrush(Colors.Red);
        }
        else
        {
            txtBox.BorderBrush = new SolidColorBrush(Colors.Green);
        }
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();
        var txtBox = this.AssociatedObject as TextBox;
        txtBox.TextChanged -= this.OnTextChanged;
    }
}
