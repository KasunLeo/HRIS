Module mod_EditEmployee
    Public strFillComboString As String
    Public sDefaultComboText As String
    Public strChange As String
    Public strEmployee As String
    Public strUpdateField As String
    Public strIfIDValue As Boolean
    Public strEditWhat As String

    Public Function EditEmployee(ByVal sComboboxFillString As String, ByVal DefaultComboBoxText As String, ByVal sChange As String, ByVal EmployeewithID As String, ByVal UpdateField As String, ByVal sComboExistswithID As String, ByVal EditWhat As String) As Boolean
        strFillComboString = sComboboxFillString
        sDefaultComboText = DefaultComboBoxText
        strChange = sChange
        strEmployee = EmployeewithID
        strUpdateField = UpdateField
        strIfIDValue = sComboExistswithID
        strEditWhat = EditWhat
        'Dim FS As New FrmEditEmployee
        'FS.ShowDialog()
    End Function

End Module
