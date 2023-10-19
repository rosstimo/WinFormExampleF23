Public Class WinFormExampleForm

    Dim fruits As New List(Of String)

    ' Event Handler Section
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub ActionButton_Click(sender As Object, e As EventArgs) Handles ActionButton.Click
        Me.Text = ExampleTextBox.Text
        'reverse only if reverse check box is checked
        If StringReverseCheckBox.Checked Then
            ExampleTextBox.Text = StrReverse(ExampleTextBox.Text)
        End If

        'ExampleListBox.Items.Add(ExampleTextBox.Text)
        'ExampleComboBox.Items.Add(ExampleTextBox.Text)
        AddItem()
    End Sub

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        Try
            ExampleListBox.Items.RemoveAt(ExampleListBox.SelectedIndex)
            ExampleComboBox.Items.RemoveAt(ExampleComboBox.SelectedIndex)
        Catch ex As Exception
            'do nothing
        End Try
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

    Private Sub WinFormExampleForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetListDefaults()
        DisplayList()

        ExampleComboBox.SelectedIndex = 0

    End Sub

    'custom methods

    ''' <summary>
    ''' Clear the list of fruits and return to a known default state
    ''' </summary>
    Private Sub SetListDefaults()
        Me.fruits.Clear()
        Me.fruits.Add("Apple")
        Me.fruits.Add("Grape")
        Me.fruits.Add("Banana")
        Me.fruits.Add("Lemon")
        Me.fruits.Add("Tomato")
    End Sub

    ''' <summary>
    ''' Update all list controls with the current list of fruits
    ''' </summary>
    Private Sub DisplayList()
        ExampleListBox.Items.Clear()
        ExampleComboBox.Items.Clear()

        For Each fruit As String In Me.fruits
            ExampleListBox.Items.Add(fruit)
            ExampleComboBox.Items.Add(fruit)
        Next
    End Sub

    ''' <summary>
    ''' Add the contents of the text box to the list of fruits
    '''
    ''' <list> 
    ''' <item>
    ''' <description>
    ''' Avoid adding empty items
    ''' </description>
    ''' </item>
    ''' <item>
    ''' <description>
    ''' Avoid adding duplicates
    ''' </description>
    ''' </item>
    ''' </list>
    ''' </summary>
    Sub AddItem()

        If ExampleTextBox.Text <> "" _
           And Not ExampleListBox.Items.Contains(ExampleTextBox.Text) _
           And Not ExampleComboBox.Items.Contains(ExampleTextBox.Text) Then
            fruits.Add(ExampleTextBox.Text)
        End If
        DisplayList()
    End Sub

End Class
