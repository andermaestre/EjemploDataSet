Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListView1.Clear()
        LlenarColumnas(ListView1)
        LLenarFilas(ListView1)
    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        daUsuarios.Fill(ds, "Usuarios")
        Dim t As DataTable = ds.Tables("Usuarios")
        Dim key(0) As DataColumn
        key(0) = t.Columns("IdUsuario")
        t.PrimaryKey = key
    End Sub

    Private Sub MantenimientoUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoUsuariosToolStripMenuItem.Click
        frmMantenimiento.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListView1.Clear()
        LlenarColumnas(ListView1)
        LLenarFilasOriginal(ListView1)
    End Sub

    Private Sub CancelarCambiosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelarCambiosToolStripMenuItem.Click
        ds.RejectChanges()
    End Sub

    Private Sub GuardarCambiosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarCambiosToolStripMenuItem.Click
        Try
            daUsuarios.Update(ds.Tables("Usuarios"))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
