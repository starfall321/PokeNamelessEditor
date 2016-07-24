Module getname
    Public Function getchar(ByRef offset As Integer) As String
        Dim current_byte As String
        Dim count As Integer = 0
        Dim current_string As String = ""
        Dim filepath As String = Form1.filepath_label.Text
        current_byte = "00"
        While current_byte <> "FF"
            current_byte = ReadHEX(filepath, offset + count, 1)
            Dim i As Integer = Convert.ToInt32(current_byte, 16)
            If i < &H1F Then
                current_byte = ReadHEX(filepath, offset + count, 2)
                current_string += poke_encoding(current_byte)
                count += 2
            Else
                current_byte = ReadHEX(filepath, offset + count, 1)
                current_string += poke_encoding(current_byte)
                count += 1
            End If
            current_byte = ReadHEX(filepath, offset + count, 1)
        End While
        Return current_string
    End Function

    Public Function getpokename()

    End Function

End Module
