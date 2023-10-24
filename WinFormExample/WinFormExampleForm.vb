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
        'Try
        '    ExampleListBox.Items.RemoveAt(ExampleListBox.SelectedIndex)
        '    ExampleComboBox.Items.RemoveAt(ExampleComboBox.SelectedIndex)
        'Catch ex As Exception
        '    'do nothing
        'End Try
        If ExampleListBox.SelectedIndex >= 0 Then
            Try
                RemoveItem(ExampleListBox.SelectedItem.ToString)
            Catch ex As Exception
                'do nothing
            End Try
        End If

    End Sub

    Private Sub SyncListControlIndex(sender As Object, e As EventArgs) Handles ExampleListBox.SelectedIndexChanged, ExampleComboBox.SelectedIndexChanged
        Try
            'set the text box to the selected item
            If ExampleListBox.SelectedIndex >= 0 Then

                'synchronize list controls
                If sender.Equals(ExampleListBox) Then
                    ExampleComboBox.SelectedIndex = ExampleListBox.SelectedIndex
                Else
                    ExampleListBox.SelectedIndex = ExampleComboBox.SelectedIndex
                End If

                'enable remove button
                RemoveButton.Enabled = True

                'update top bar and text box with current selection
                Me.Text = ExampleListBox.SelectedItem.ToString
                ExampleTextBox.Text = ExampleListBox.SelectedItem.ToString

            Else
                RemoveButton.Enabled = False
            End If

        Catch oops As System.NullReferenceException
            'do nothing
        Catch ex As Exception
            'do nothing
            MsgBox(ExampleListBox.SelectedIndex)

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
        Me.fruits.Add("Banana")
        Me.fruits.Add("Banana")
        Me.fruits.Add("Banana")
        Me.fruits.Add("Banana")
        Me.fruits.Add("Lemon")
        Me.fruits.Add("Tomato")
        Me.fruits.Add("Banana")
        Me.fruits.Add("Banana")
        Me.fruits.Add("Banana")
        Me.fruits.Add("Banana")
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

    Sub RemoveItem(currentItem As String)

        Try
            Do While fruits.Contains(currentItem)
                Me.fruits.Remove(currentItem)
            Loop
        Catch ex As Exception
            'do nothing
        End Try
        DisplayList()
    End Sub


End Class
