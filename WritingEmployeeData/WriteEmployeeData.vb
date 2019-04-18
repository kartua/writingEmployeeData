Imports System.IO

Public Class WriteEmployeeData
    Dim strFilePath As String
    Dim ResponseSaveDialogResult As DialogResult
    Dim employeeFile As StreamWriter

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            With SaveFileDialog1
                ' Display the current directory in the window
                .InitialDirectory = Directory.GetCurrentDirectory
                ' Display a file name in the filename box
                .FileName = "employee.txt"
                ' Display a title for the OPEN dialog window
                .Title = "Select File or Directory for File"
                ' Save the user response - OPEN or CANCEL
                ResponseSaveDialogResult = .ShowDialog
            End With
            If ResponseSaveDialogResult <> DialogResult.Cancel Then
                strFilePath = SaveFileDialog1.FileName
                employeeFile = File.CreateText(strFilePath)
                employeeFile.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtFirstName.Text = String.Empty
        txtMiddleName.Text = String.Empty
        txtLastName.Text = String.Empty
        txtEmployeeNumber.Text = String.Empty
        cboDepartment.Text = String.Empty
        txtTelephone.Text = String.Empty
        txtExtension.Text = String.Empty
        txtEmail.Text = String.Empty
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        employeeFile = File.AppendText(strFilePath)
        employeeFile.WriteLine(txtFirstName.Text)
        employeeFile.WriteLine(txtMiddleName.Text)
        employeeFile.WriteLine(txtLastName.Text)
        employeeFile.WriteLine(txtEmployeeNumber.Text)
        employeeFile.WriteLine(cboDepartment.Text)
        employeeFile.WriteLine(txtTelephone.Text)
        employeeFile.WriteLine(txtExtension.Text)
        employeeFile.WriteLine(txtEmail.Text)

        employeeFile.Close()
        MessageBox.Show("The record has been saved.")

    End Sub
End Class
