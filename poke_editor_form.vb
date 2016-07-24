Public Class poke_editor_form


    Private Sub poked_editor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = Form1.filepath_label.Text
        Dim filepath As String = Form1.filepath_label.Text
        Dim AppPath As String
        AppPath = Application.StartupPath
        Dim ini As New Inifile(AppPath & "\INI.txt")

        'get header
        Dim header As String = ""
        Dim header_hex As String
        header_hex = ReadHEX(filepath, &HAC, 4)
        For x = 0 To header_hex.Length - 1 Step 2
            header += ChrW(CInt("&H" & header_hex.Substring(x, 2)))
        Next
        header_label.Text = header

        'get offset
        Dim poke_name_offset As String
        Dim poke_ability_offset As String
        Dim poke_ability_number As String
        Dim poke_number As String
        Dim type_ As String
        Dim type_number As String
        Dim type_name_offset As String
        Dim item_number As String
        Dim item_data_offset As String
        Dim evo_no As Integer = 0
        Dim evolution_number As String
        evolution_number = Convert.ToInt32(ini.ReadValue(header, "EvolutionPerPokemon"), 10)
        While evo_no < evolution_number
            ListBox1.Items.Add("进化分支" & evo_no + 1)
            evo_no += 1
        End While

        poke_name_offset = Convert.ToInt32(ini.ReadValue(header, "PokeName"), 16)
        poke_ability_offset = Convert.ToInt32(ini.ReadValue(header, "AbilityName"), 16)
        poke_ability_number = Convert.ToInt32(ini.ReadValue(header, "AbilityNumber"), 10)
        poke_number = Convert.ToInt32(ini.ReadValue(header, "PokeNumber"), 10)
        type_name_offset = Convert.ToInt32(ini.ReadValue(header, "TypeName"), 16)
        type_number = Convert.ToInt32(ini.ReadValue(header, "TypeNumber"), 10)
        item_data_offset = Convert.ToInt32(ini.ReadValue(header, "ItemData"), 16)
        item_number = Convert.ToInt32(ini.ReadValue(header, "ItemNumber"), 10)

        Dim poke_name As String
        Dim poke_ability As String
        Dim item_name As String
        Dim count As Integer = 0
        While count < poke_number
            poke_name = getchar(poke_name_offset + count * 11)
            ComboBox1.Items.Add(poke_name)
            ComboBox15.Items.Add(poke_name)
            count += 1
        End While

        count = 0
        While count <= poke_ability_number
            poke_ability = getchar(poke_ability_offset + count * 13)
            ComboBox4.Items.Add(poke_ability)
            ComboBox5.Items.Add(poke_ability)
            ComboBox13.Items.Add(poke_ability)
            count += 1
        End While

        count = 0
        While count <= type_number
            type_ = getchar(type_name_offset + count * 7)
            ComboBox2.Items.Add(type_)
            ComboBox3.Items.Add(type_)
            count += 1
        End While

        count = 0
        While count <= item_number
            item_name = getchar(item_data_offset + count * 44)
            ComboBox6.Items.Add(item_name)
            ComboBox7.Items.Add(item_name)
            ComboBox_item.Items.Add(item_name)
            count += 1
        End While
        ComboBox16.Items.AddRange(System.IO.File.ReadAllLines(AppPath & "\EvolutionMethod.txt"))

        Dim move_number As Integer
        Dim move_name_offset As String
        Dim move_name As String
        move_number = Convert.ToInt32(ini.ReadValue(header, "MoveNumber"), 10)
        move_name_offset = Convert.ToInt32(ini.ReadValue(header, "MoveName"), 16)
        count = 0
        While count <= move_number
            move_name = getchar(move_name_offset + count * 13)
            ComboBox_move.Items.Add(move_name)
            ComboBox17.Items.Add(move_name)
            count += 1
        End While

    End Sub

    Private Sub ComboBox1_selectedindexchanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim AppPath As String
        AppPath = Application.StartupPath
        Dim ini As New Inifile(AppPath & "\INI.txt")
        Dim filepath As String = Label1.Text
        Dim hp As String
        Dim atk As String
        Dim def As String
        Dim speed As String
        Dim sp_atk As String
        Dim sp_def As String
        Dim pokebasestat As Integer
        Dim poke_basestat_offset As String
        Dim header As String = header_label.Text
        Dim ability1 As String
        Dim ability2 As String
        Dim ability3 As String
        Dim item1 As String
        Dim item2 As String
        Dim type1 As String
        Dim type2 As String
        Dim catchrate As String
        Dim baseexp As String
        Dim gender_ratio As String
        Dim lvlup_type As String
        Dim egggroup1 As String
        Dim egggroup2 As String
        Dim eggcycle As String
        Dim fleerate As String
        Dim basehappiness As String
        Dim color As String
        Dim flip As Boolean = False
        Dim evyield As String
        Dim hp_ev As Integer = 0
        Dim atk_ev As Integer = 0
        Dim def_ev As Integer = 0
        Dim spd_ev As Integer = 0
        Dim sp_atk_ev As Integer = 0
        Dim sp_def_ev As Integer = 0
        Dim pokedex_data_offset As String
        Dim pokedex_text As String
        pokedex_data_offset = Convert.ToInt32(ini.ReadValue(header, "PokedexData"), 16)
        poke_basestat_offset = Convert.ToInt32(ini.ReadValue(header, "PokeData"), 16)
        pokebasestat = poke_basestat_offset + ComboBox1.SelectedIndex * &H1C
        hp = ReadHEX(filepath, pokebasestat + 0, 1)
        atk = ReadHEX(filepath, pokebasestat + 1, 1)
        def = ReadHEX(filepath, pokebasestat + 2, 1)
        speed = ReadHEX(filepath, pokebasestat + 3, 1)
        sp_atk = ReadHEX(filepath, pokebasestat + 4, 1)
        sp_def = ReadHEX(filepath, pokebasestat + 5, 1)
        type1 = ReadHEX(filepath, pokebasestat + 6, 1)
        type2 = ReadHEX(filepath, pokebasestat + 7, 1)
        catchrate = ReadHEX(filepath, pokebasestat + 8, 1)
        baseexp = ReadHEX(filepath, pokebasestat + 9, 1)
        gender_ratio = ReadHEX(filepath, pokebasestat + 16, 1)
        lvlup_type = ReadHEX(filepath, pokebasestat + 19, 1)
        ability1 = ReadHEX(filepath, pokebasestat + 22, 1)
        ability2 = ReadHEX(filepath, pokebasestat + 23, 1)
        ability3 = ReadHEX(filepath, pokebasestat + 27, 1)
        item1 = ReverseHEX(ReadHEX(filepath, pokebasestat + 12, 2))
        item2 = ReverseHEX(ReadHEX(filepath, pokebasestat + 14, 2))
        egggroup1 = ReadHEX(filepath, pokebasestat + 20, 1)
        egggroup2 = ReadHEX(filepath, pokebasestat + 21, 1)
        eggcycle = ReadHEX(filepath, pokebasestat + 17, 1)
        fleerate = ReadHEX(filepath, pokebasestat + 24, 1)
        basehappiness = ReadHEX(filepath, pokebasestat + 18, 1)
        color = Convert.ToInt32(ReadHEX(filepath, pokebasestat + 25, 1), 16)
        evyield = Convert.ToInt32(ReverseHEX(ReadHEX(filepath, pokebasestat + 10, 2)), 16)
        hp_ev = (evyield And &H3)
        If (evyield And &HC) > &H3 Then
            atk_ev = (evyield And &HC) / &H4
        End If

        If (evyield And &H1E) > &HF Then
            def_ev = (evyield And &H1E) / &H10
        End If

        If (evyield And &HC0) > &H3F Then
            spd_ev = (evyield And &HC0) / &H40
        End If

        If (evyield And &H300) > &HFF Then
            sp_atk_ev = (evyield And &H300) / &H100
        End If

        If (evyield And &HC00) > &H3FF Then
            sp_def_ev = (evyield And &HC00) / &H400
        End If

        If color >= 128 Then
            color -= 128
            flip = True
        End If

        Select Case gender_ratio
            Case "00" : gender_ratio = 0
            Case "1F" : gender_ratio = 1
            Case "3F" : gender_ratio = 2
            Case "59" : gender_ratio = 3
            Case "7F" : gender_ratio = 4
            Case "A5" : gender_ratio = 5
            Case "BF" : gender_ratio = 6
            Case "DF" : gender_ratio = 7
            Case "FE" : gender_ratio = 8
            Case "FF" : gender_ratio = 9
        End Select
        ComboBox6.SelectedIndex = Convert.ToInt32(item1, 16)
        ComboBox7.SelectedIndex = Convert.ToInt32(item2, 16)
        ComboBox10.SelectedIndex = gender_ratio
        ComboBox12.SelectedIndex = lvlup_type
        txtboxhp.Text = Convert.ToInt32(hp, 16)
        txtboxatk.Text = Convert.ToInt32(atk, 16)
        txtboxdef.Text = Convert.ToInt32(def, 16)
        txtboxspeed.Text = Convert.ToInt32(speed, 16)
        txtboxsp_atk.Text = Convert.ToInt32(sp_atk, 16)
        txtboxsp_def.Text = Convert.ToInt32(sp_def, 16)
        ComboBox2.SelectedIndex = Convert.ToInt32(type1, 16)
        ComboBox3.SelectedIndex = Convert.ToInt32(type2, 16)
        TextBox1.Text = Convert.ToInt32(catchrate, 16)
        TextBox2.Text = Convert.ToInt32(baseexp, 16)
        TextBox8.Text = hp_ev
        TextBox7.Text = atk_ev
        TextBox6.Text = def_ev
        TextBox5.Text = spd_ev
        TextBox4.Text = sp_atk_ev
        TextBox3.Text = sp_def_ev
        TextBox9.Text = Convert.ToInt32(basehappiness, 16)
        TextBox10.Text = (Convert.ToInt32(eggcycle, 16) * 256)
        TextBox11.Text = Convert.ToInt32(fleerate, 16)
        ComboBox4.SelectedIndex = Convert.ToInt32(ability1, 16)
        ComboBox5.SelectedIndex = Convert.ToInt32(ability2, 16)
        ComboBox13.SelectedIndex = Convert.ToInt32(ability3, 16)
        ComboBox8.SelectedIndex = Convert.ToInt32(egggroup1, 16)
        ComboBox9.SelectedIndex = Convert.ToInt32(egggroup2, 16)
        ComboBox11.SelectedIndex = color
        CheckBox1.Checked = flip

        'pokedex text
        Dim height As Decimal
        Dim weight As Decimal
        Dim text_offset As String
        Dim dex_number As Integer
        Dim national_dex_table As String
        Dim pokedex_number As String
        Dim poke_category As String
        pokedex_number = Convert.ToInt32(ini.ReadValue(header, "PokedexNumber"), 10)
        national_dex_table = Convert.ToInt32(ini.ReadValue(header, "NationalDexTable"), 16)
        dex_number = Convert.ToInt32(ReverseHEX(ReadHEX(filepath, national_dex_table + (ComboBox1.SelectedIndex - 1) * 2, 2)), 16)

        If ComboBox1.SelectedIndex = 0 Then
            dex_number = 0
        End If

        If dex_number = 0 Then
            text_offset = Convert.ToInt32(ReverseHEX(ReadHEX(filepath, (pokedex_data_offset + &H10), 4)), 16) - &H8000000
            pokedex_text = getchar(text_offset)
            RichTextBox1.Text = pokedex_text
            height = Convert.ToInt32(ReverseHEX(ReadHEX(filepath, (pokedex_data_offset + 12), 2)), 16)
            weight = Convert.ToInt32(ReverseHEX(ReadHEX(filepath, (pokedex_data_offset + 14), 2)), 16)
            poke_category = getchar(pokedex_data_offset)
            TextBox22.Text = poke_category
            Label43.Text = Format((height / 10), "0.0") & " m"
            Label44.Text = Format((weight / 10), "0.0") & " kg"
            TextBox20.Text = height
            TextBox21.Text = weight
            TextBox20.Enabled = True
            TextBox21.Enabled = True
            TextBox22.Enabled = True
            RichTextBox1.Enabled = True
            Button3.Enabled = True
        Else
            If dex_number <= pokedex_number Then
                text_offset = Convert.ToInt32(ReverseHEX(ReadHEX(filepath, (pokedex_data_offset + dex_number * &H20 + &H10), 4)), 16) - &H8000000
                pokedex_text = getchar(text_offset)
                poke_category = getchar(pokedex_data_offset + dex_number * &H20)
                TextBox22.Text = poke_category
                RichTextBox1.Text = pokedex_text
                height = Convert.ToInt32(ReverseHEX(ReadHEX(filepath, (pokedex_data_offset + dex_number * &H20 + 12), 2)), 16)
                weight = Convert.ToInt32(ReverseHEX(ReadHEX(filepath, (pokedex_data_offset + dex_number * &H20 + 14), 2)), 16)
                Label43.Text = Format((height / 10), "0.0") & " m"
                Label44.Text = Format((weight / 10), "0.0") & " kg"
                TextBox20.Text = height
                TextBox21.Text = weight
                TextBox20.Enabled = True
                TextBox21.Enabled = True
                TextBox22.Enabled = True
                RichTextBox1.Enabled = True
                Button3.Enabled = True
            Else
                RichTextBox1.Text = ""
                TextBox20.Text = ""
                TextBox21.Text = ""
                TextBox22.Text = ""
                Label43.Text = ""
                Label44.Text = ""
                TextBox20.Enabled = False
                TextBox21.Enabled = False
                TextBox22.Enabled = False
                RichTextBox1.Enabled = False
                Button3.Enabled = False
            End If
        End If

        'evolution data
        Dim poke_evo_offset As String
        Dim method As String
        Dim poke_evo As Integer
        Dim evolution_number As String
        Dim parameter As String
        Dim parameter_type As String
        evolution_number = Convert.ToInt32(ini.ReadValue(header, "EvolutionPerPokemon"), 10)

        poke_evo_offset = Convert.ToInt32(ini.ReadValue(header, "EvolutionData"), 16)
        method = Convert.ToInt32(ReverseHEX(ReadHEX(filepath, poke_evo_offset + ComboBox1.SelectedIndex * evolution_number * 8, 2)), 16)
        parameter = Convert.ToInt32(ReverseHEX(ReadHEX(filepath, poke_evo_offset + ComboBox1.SelectedIndex * evolution_number * 8 + 2, 2)), 16)
        poke_evo = Convert.ToInt32(ReverseHEX(ReadHEX(filepath, poke_evo_offset + ComboBox1.SelectedIndex * evolution_number * 8 + 4, 2)), 16)
        ListBox1.SelectedIndex = 0

        parameter_type = ini.ReadValue(header, "EvolutionMethod" & method)
        If parameter_type = "level" Then
            Label54.Visible = True
            ComboBox15.Enabled = True
            TextBox28.Visible = True
            ComboBox_item.Visible = False
            ComboBox_move.Visible = False
            ComboBox_type.Visible = False
            TextBox28.Text = parameter
        ElseIf parameter_type = "item" Then
            Label54.Visible = True
            ComboBox15.Enabled = True
            TextBox28.Visible = False
            ComboBox_item.Visible = True
            ComboBox_move.Visible = False
            ComboBox_type.Visible = False
            ComboBox_item.SelectedIndex = parameter
        ElseIf parameter_type = "move" Then
            Label54.Visible = True
            ComboBox15.Enabled = True
            TextBox28.Visible = False
            ComboBox_item.Visible = False
            ComboBox_move.Visible = True
            ComboBox_type.Visible = False
            ComboBox_move.SelectedIndex = parameter
        ElseIf parameter_type = "type" Then
            Label54.Visible = True
            ComboBox15.Enabled = True
            TextBox28.Visible = False
            ComboBox_item.Visible = False
            ComboBox_move.Visible = False
            ComboBox_type.Visible = True
            ComboBox_type.SelectedIndex = parameter
        ElseIf parameter_type = "none" Then
            Label54.Visible = False
            TextBox28.Visible = False
            ComboBox_item.Visible = False
            ComboBox_move.Visible = False
            ComboBox_type.Visible = False

        End If

        If method = 0 Then
            ComboBox15.SelectedIndex = 0
            ComboBox15.Enabled = False
        Else
            ComboBox15.Enabled = True
            ComboBox15.SelectedIndex = poke_evo
            ComboBox16.SelectedIndex = method
        End If

        'move data
        '1.check move extension hack
        '2.load move table offset
        '3.load pointer 
        '4.load data

        Dim move_table As String
        Dim move_pointer As String
        Dim move_count As Integer = 0
        Dim move_byte As String
        Dim level_byte As String
        ListBox2.Items.Clear()
        TextBox29.Text = ""
        ComboBox17.Text = ""
        move_table = Convert.ToInt32(ini.ReadValue(header, "PokeMoveTable"), 16)
        move_pointer = Convert.ToInt32(ReverseHEX(ReadHEX(filepath, move_table + ComboBox1.SelectedIndex * 4, 4)), 16) - &H8000000

        TextBox30.Text = Hex(move_pointer)

        While Convert.ToInt32(ReverseHEX(ReadHEX(filepath, move_pointer + move_count * 2, 2)), 16) <> &HFFFF
            level_byte = Convert.ToInt32(ReverseHEX(ReadHEX(filepath, move_pointer + move_count * 2, 2)), 16) >> 9
            move_byte = Convert.ToInt32(ReverseHEX(ReadHEX(filepath, move_pointer + move_count * 2, 2)), 16) - (level_byte << 9)
            ListBox2.Items.Add(level_byte & "     " & ComboBox17.Items(move_byte))
            move_count += 1
        End While

        TextBox31.Text = move_count

        Dim tmdata As String
        Dim tm As String



    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim AppPath As String
        AppPath = Application.StartupPath
        Dim ini As New Inifile(AppPath & "\INI.txt")
        Dim filepath As String = Label1.Text
        Dim header As String = header_label.Text

        'evolution data
        Dim poke_evo_offset As String
        Dim method As String
        Dim poke_evo As Integer
        Dim evolution_number As String
        Dim parameter As String
        Dim parameter_type As String
        evolution_number = Convert.ToInt32(ini.ReadValue(header, "EvolutionPerPokemon"), 10)

        poke_evo_offset = Convert.ToInt32(ini.ReadValue(header, "EvolutionData"), 16)
        method = Convert.ToInt32(ReverseHEX(ReadHEX(filepath, poke_evo_offset + ComboBox1.SelectedIndex * evolution_number * 8 + ListBox1.SelectedIndex * 8, 2)), 16)
        parameter = Convert.ToInt32(ReverseHEX(ReadHEX(filepath, poke_evo_offset + ComboBox1.SelectedIndex * evolution_number * 8 + 2 + ListBox1.SelectedIndex * 8, 2)), 16)
        poke_evo = Convert.ToInt32(ReverseHEX(ReadHEX(filepath, poke_evo_offset + ComboBox1.SelectedIndex * evolution_number * 8 + 4 + ListBox1.SelectedIndex * 8, 2)), 16)

        parameter_type = ini.ReadValue(header, "EvolutionMethod" & method)
        If parameter_type = "level" Then
            Label54.Visible = True
            ComboBox15.Enabled = True
            TextBox28.Visible = True
            ComboBox_item.Visible = False
            ComboBox_move.Visible = False
            ComboBox_type.Visible = False
            TextBox28.Text = parameter
        ElseIf parameter_type = "item" Then
            Label54.Visible = True
            ComboBox15.Enabled = True
            TextBox28.Visible = False
            ComboBox_item.Visible = True
            ComboBox_move.Visible = False
            ComboBox_type.Visible = False
            ComboBox_item.SelectedIndex = parameter
        ElseIf parameter_type = "move" Then
            Label54.Visible = True
            ComboBox15.Enabled = True
            TextBox28.Visible = False
            ComboBox_item.Visible = False
            ComboBox_move.Visible = True
            ComboBox_type.Visible = False
            ComboBox_move.SelectedIndex = parameter
        ElseIf parameter_type = "type" Then
            Label54.Visible = True
            ComboBox15.Enabled = True
            TextBox28.Visible = False
            ComboBox_item.Visible = False
            ComboBox_move.Visible = False
            ComboBox_type.Visible = True
            ComboBox_type.SelectedIndex = parameter
        ElseIf parameter_type = "none" Then
            Label54.Visible = False
            TextBox28.Visible = False
            ComboBox_item.Visible = False
            ComboBox_move.Visible = False
            ComboBox_type.Visible = False

        End If

        If method = 0 Then
            ComboBox15.SelectedIndex = 0
            ComboBox15.Enabled = False
        Else
            ComboBox15.Enabled = True
            ComboBox15.SelectedIndex = poke_evo
            ComboBox16.SelectedIndex = method
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        Dim AppPath As String
        AppPath = Application.StartupPath
        Dim ini As New Inifile(AppPath & "\INI.txt")
        Dim filepath As String = Label1.Text
        Dim header As String = header_label.Text

        Dim move_table As String
        Dim move_pointer As String
        Dim move_count As Integer = 0
        Dim move_byte As String
        Dim level_byte As String
        move_table = Convert.ToInt32(ini.ReadValue(header, "PokeMoveTable"), 16)
        move_pointer = Convert.ToInt32(ReverseHEX(ReadHEX(filepath, move_table + ComboBox1.SelectedIndex * 4, 4)), 16) - &H8000000

        level_byte = Convert.ToInt32(ReverseHEX(ReadHEX(filepath, move_pointer + ListBox2.SelectedIndex * 2, 2)), 16) >> 9
        move_byte = Convert.ToInt32(ReverseHEX(ReadHEX(filepath, move_pointer + ListBox2.SelectedIndex * 2, 2)), 16) - (level_byte << 9)

        TextBox29.Text = level_byte
        ComboBox17.SelectedIndex = move_byte

    End Sub
End Class

'@ Ivysaur
'base_stats 60, 62, 63, 60, 80, 80
'.byte TYPE_GRASS
'.byte TYPE_POISON
'.byte 45 @ catch rate
'.byte 141 @ base exp. yield
'ev_yield 0, 0, 0, 0, 1, 1
'.2byte ITEM_NONE
'.2byte ITEM_NONE
'.byte 31 @ gender
'.byte 20 @ egg cycles
'.byte 70 @ base friendship
'.byte GROWTH_MEDIUM_SLOW
'.byte EGG_GROUP_MONSTER
'.byte EGG_GROUP_GRASS
'.byte ABILITY_OVERGROW
'.byte ABILITY_NONE
'.byte 0 @ Safari Zone flee rate
'.byte BODY_COLOR_GREEN
'.2byte 0 @ padding