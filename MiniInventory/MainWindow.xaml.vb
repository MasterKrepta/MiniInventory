Imports System.Data
Imports MySql.Data.MySqlClient

Class MainWindow
    Dim myConn As New MySqlConnection("host=127.0.0.1; user=root; password=OKaKaekJpMWbc4Eg; SslMode=none; database=malish_test")



    Private Sub button1_Click(sender As Object, e As RoutedEventArgs) Handles button1.Click


        GetData()
    End Sub

    Private Sub GetData()
        Try
            myConn.Open()
            'MessageBox.Show("It works")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Dim cmd As New MySqlCommand
        cmd.CommandText = "SELECT * FROM inventory"
        cmd.Connection = myConn
        Dim da As New MySqlDataAdapter
        Dim dt As New DataTable("inventory")
        da.SelectCommand = cmd
        da.Fill(dt)


        myContentPresenter.DataContext = dt


        'MessageBox.Show("We showed the data")
        myConn.Close()

    End Sub
End Class
