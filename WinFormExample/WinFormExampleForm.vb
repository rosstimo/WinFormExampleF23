Public Class WinFormExampleForm
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub ActionButton_Click(sender As Object, e As EventArgs) Handles ActionButton.Click
        Me.Text = ExampleTextBox.Text
        'reverse only if reverse check box is checked
        If StringReverseCheckBox.Checked Then
            ExampleTextBox.Text = StrReverse(ExampleTextBox.Text)
        End If

        ExampleListBox.Items.Add(ExampleTextBox.Text)
        ExampleComboBox.Items.Add(ExampleTextBox.Text)
    End Sub

    Private Sub WinFormExampleForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        'add 5 fruits to the list box
        ExampleListBox.Items.Add("Apple")
        ExampleListBox.Items.Add("Grape")
        ExampleListBox.Items.Add("Banana")
        ExampleListBox.Items.Add("Lemon")
        ExampleListBox.Items.Add("Tomato")

        'add 5 fruits to the combo box
        ExampleComboBox.Items.Add("Apple")
        ExampleComboBox.Items.Add("Grape")
        ExampleComboBox.Items.Add("Banana")
        ExampleComboBox.Items.Add("Lemon")
        ExampleComboBox.Items.Add("Tomato")


        ExampleComboBox.SelectedIndex = 0

    End Sub

    Private Sub ExampleListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ExampleListBox.SelectedIndexChanged
        Try
            'set the text box to the selected item
            'MsgBox(ExampleListBox.SelectedIndex)
            If ExampleListBox.SelectedIndex >= 0 Then
                Me.Text = ExampleListBox.SelectedItem.ToString
                ExampleTextBox.Text = ExampleListBox.SelectedItem.ToString
                ExampleComboBox.SelectedIndex = ExampleListBox.SelectedIndex
            End If

        Catch oops As System.NullReferenceException
            'do nothing
        Catch ex As Exception
            'do nothing
            MsgBox(ExampleListBox.SelectedIndex)

        End Try
    End Sub

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        Try
            ExampleListBox.Items.RemoveAt(ExampleListBox.SelectedIndex)
            ExampleComboBox.Items.RemoveAt(ExampleComboBox.SelectedIndex)
        Catch ex As Exception
            'do nothing
        End Try
    End Sub

    Private Sub ExampleComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ExampleComboBox.SelectedIndexChanged
        Try
            'set the text box to the selected item
            'MsgBox(ExampleComboBox.SelectedIndex)
            If ExampleComboBox.SelectedIndex >= 0 Then
                Me.Text = ExampleComboBox.SelectedItem.ToString
                ExampleTextBox.Text = ExampleComboBox.SelectedItem.ToString
                ExampleListBox.SelectedIndex = ExampleComboBox.SelectedIndex
            End If

        Catch oops As System.NullReferenceException
            'do nothing
        Catch ex As Exception
            'do nothing
            MsgBox(ExampleComboBox.SelectedIndex)

        End Try
    End Sub
End Class
