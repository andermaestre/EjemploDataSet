Module Module1
    Public cadena As String = "Data Source=SEGUNDO150;Initial Catalog=DaniDB;Integrated Security=True"
    Public daUsuarios As New SqlDataAdapter("SELECT * FROM Foro.Usuarios", cadena)
    Public builder As New SqlCommandBuilder(daUsuarios)
    Public ds As New DataSet
    Public Sub InicializarDataAdapter()
        daUsuarios.UpdateCommand = builder.GetUpdateCommand()
        daUsuarios.DeleteCommand = builder.GetDeleteCommand()
        daUsuarios.InsertCommand = builder.GetInsertCommand()
    End Sub
    Public Sub LLenarFilas(listView1 As ListView)
        For Each r As DataRow In ds.Tables("Usuarios").Rows

            Dim it As ListViewItem
            If r.RowState = DataRowState.Deleted Then
                it = listView1.Items.Add("----")
            Else
                it = listView1.Items.Add(r("idUsuario").ToString)
            End If
            For i As Integer = 1 To ds.Tables("Usuarios").Columns.Count - 1
                If r.RowState = DataRowState.Deleted Then
                    it.SubItems.Add("----")
                Else
                    it.SubItems.Add(r(i).ToString)
                End If
            Next

            it.SubItems.Add(r.RowState.ToString)
        Next

    End Sub


    Public Sub LlenarColumnas(listView1 As ListView)
        For Each c As DataColumn In ds.Tables("Usuarios").Columns
            listView1.Columns.Add(c.ColumnName)
        Next
        listView1.Columns.Add("RowState")
    End Sub


    Public Sub LLenarFilasOriginal(listView1 As ListView)
        For Each r As DataRow In ds.Tables("Usuarios").Rows
            If r.RowState = DataRowState.Deleted Then
                Exit Sub
            End If
            Dim it As ListViewItem

            it = listView1.Items.Add(r("idUsuario", DataRowVersion.Original).ToString)

            For i As Integer = 1 To ds.Tables("Usuarios").Columns.Count - 1

                it.SubItems.Add(r(i, DataRowVersion.Original).ToString)

            Next

            it.SubItems.Add(r.RowState.ToString)
        Next
    End Sub
End Module
