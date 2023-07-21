Imports System
Imports System.Runtime.Intrinsics.X86

Module Program
    Sub Main(args As String())
        Console.WriteLine("Tarea")
        Console.WriteLine("Digite una cantidad entre 0 y 99999: ")
        Dim cantidad As Single = Single.Parse(Console.ReadLine())

        Console.WriteLine("La cantidad en numero es: " & cantidad)

        Dim centavos As Single = cantidad Mod 1
        centavos = Math.Round(centavos, 2)
        cantidad = cantidad - centavos
        Dim unidades As Integer = cantidad Mod 10
        cantidad = cantidad - unidades
        Dim decenas As Integer = cantidad Mod 100
        cantidad = cantidad - decenas
        Dim centenas As Integer = cantidad Mod 1000
        cantidad = cantidad - centenas
        Dim unidadesMillar As Integer = cantidad Mod 10000
        cantidad = cantidad - unidadesMillar
        Dim decenasMillar As Integer = cantidad Mod 100000
        cantidad = cantidad - decenasMillar
        Console.WriteLine("Centavos: " & centavos)
        Console.WriteLine("Unidades: " & unidades)
        Console.WriteLine("Lleva Y: " & LlevaY(unidades, decenas, False))
        Console.WriteLine("Decenas: " & decenas)
        Console.WriteLine("Es Especial: " & EsEspecial(unidades, decenas, False))
        Console.WriteLine("Centenas: " & centenas)
        Console.WriteLine("Unidades de Millar: " & unidadesMillar)
        Console.WriteLine("Lleva Y: " & LlevaY(unidadesMillar, decenasMillar, True))
        Console.WriteLine("Decenas de Millar: " & decenasMillar)
        Console.WriteLine("Es Especial: " & EsEspecial(unidadesMillar, decenasMillar, True))
        Dim unidadestxt As String = NombreUnidades(unidades)
        Dim decenastxt As String = NombreDecenas(decenas)
        If EsEspecial(unidades, decenas, False) Then
            decenastxt = NumeroEspecial(unidades, decenas, False)
            unidadestxt = ""
        End If
        Dim centenastxt As String = NombreCentenas(centenas)
        If centenas = 100 And (unidades <> 0 Or decenas <> 0) Then
            centenastxt = "CIENTO"
        End If
        Dim unidadesMillartxt As String = NombreUnidadesMillar(unidadesMillar)
        Dim decenasMillartxt As String = NombreDecenasMillar(decenasMillar)
        If EsEspecial(unidadesMillar, decenasMillar, True) Then
            decenasMillartxt = NumeroEspecial(unidadesMillar, decenasMillar, True)
            unidadesMillartxt = ""
        End If
        Console.WriteLine("Unidades en texto: " & unidadestxt)
        Console.WriteLine("Decenas en texto: " & decenastxt)
        Console.WriteLine("Centenas en texto: " & centenastxt)
        Console.WriteLine("Unidades de Millar en texto: " & unidadesMillartxt)
        Console.WriteLine("Decenas de Millar en texto: " & decenasMillartxt)
        Dim cantidadtxt As String = ""
        If decenasMillartxt <> "" Then
            cantidadtxt = cantidadtxt & decenasMillartxt & " "
        End If
        If LlevaY(unidadesMillar, decenasMillar, True) Then
            cantidadtxt = cantidadtxt & "Y "
        End If
        If unidadesMillartxt <> "" Then
            cantidadtxt = cantidadtxt & unidadesMillartxt & " "
        End If
        If decenasMillartxt <> "" Or unidadesMillartxt <> "" Then
            cantidadtxt = cantidadtxt & "MIL "
        End If
        If centenastxt <> "" Then
            cantidadtxt = cantidadtxt & centenastxt & " "
        End If
        If decenastxt <> "" Then
            cantidadtxt = cantidadtxt & decenastxt & " "
        End If
        If LlevaY(unidades, decenas, False) Then
            cantidadtxt = cantidadtxt & "Y "
        End If
        If unidadestxt <> "" Then
            cantidadtxt = cantidadtxt & unidadestxt & " "
        End If
        If centenastxt <> "" Or decenastxt <> "" Or unidadestxt <> "" Then
            cantidadtxt = cantidadtxt & "PESOS "
        End If
        If centavos <> 0 Then
            centavos = centavos * 100
            cantidadtxt = cantidadtxt & centavos & "/100 "
        End If
        If decenasMillartxt <> "" Or unidadesMillartxt <> "" Or centenastxt <> "" Or decenastxt <> "" Or unidadestxt <> "" Then
            cantidadtxt = cantidadtxt & "M.N."
        End If
        Console.WriteLine(cantidadtxt)
    End Sub

    Function NombreUnidades(numero As Integer) As String
        If numero = 1 Then
            Return "UN"
        ElseIf numero = 2 Then
            Return "DOS"
        ElseIf numero = 3 Then
            Return "TRES"
        ElseIf numero = 4 Then
            Return "CUATRO"
        ElseIf numero = 5 Then
            Return "CINCO"
        ElseIf numero = 6 Then
            Return "SEIS"
        ElseIf numero = 7 Then
            Return "SIETE"
        ElseIf numero = 8 Then
            Return "OCHO"
        ElseIf numero = 9 Then
            Return "NUEVE"
        End If
        Return ""
    End Function

    Function NombreDecenas(numero As Integer) As String
        If numero = 10 Then
            Return "DIEZ"
        ElseIf numero = 20 Then
            Return "VEINTE"
        ElseIf numero = 30 Then
            Return "TREINTA"
        ElseIf numero = 40 Then
            Return "CUARENTA"
        ElseIf numero = 50 Then
            Return "CINCUENTA"
        ElseIf numero = 60 Then
            Return "SESENTA"
        ElseIf numero = 70 Then
            Return "SETENTA"
        ElseIf numero = 80 Then
            Return "OCHENTA"
        ElseIf numero = 90 Then
            Return "NOVENTA"
        End If
        Return ""
    End Function

    Function NombreCentenas(numero As Integer) As String
        If numero = 100 Then
            Return "CIEN"
        ElseIf numero = 200 Then
            Return "DOSCIENTOS"
        ElseIf numero = 300 Then
            Return "TRESCIENTOS"
        ElseIf numero = 400 Then
            Return "CUATROCIENTOS"
        ElseIf numero = 500 Then
            Return "QUINIENTOS"
        ElseIf numero = 600 Then
            Return "SEICIENTOS"
        ElseIf numero = 700 Then
            Return "SETECIENTOS"
        ElseIf numero = 800 Then
            Return "OCHOCIENTOS"
        ElseIf numero = 900 Then
            Return "NOVECIENTOS"
        End If
        Return ""
    End Function

    Function NombreUnidadesMillar(numero As Integer) As String
        numero = numero / 1000
        Dim nombre As String = NombreUnidades(numero)
        If nombre <> "" Then
            Return nombre
        Else
            Return ""
        End If
    End Function

    Function NombreDecenasMillar(numero As Integer) As String
        numero = numero / 1000
        Dim nombre As String = NombreDecenas(numero)
        If nombre <> "" Then
            Return nombre
        Else
            Return ""
        End If
    End Function

    Function EsEspecial(unid As Integer, dece As Integer, millar As Boolean) As Boolean
        If millar Then
            unid = unid / 1000
            dece = dece / 1000
        End If
        Dim numero As Integer = unid + dece
        If numero = 20 Then
            Return False
        ElseIf numero > 10 And numero < 30 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function LlevaY(unid As Integer, dece As Integer, millar As Boolean) As Boolean
        If millar Then
            unid = unid / 1000
            dece = dece / 1000
        End If
        If dece > 30 And unid <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Function NumeroEspecial(unid As Integer, dece As Integer, millar As Boolean) As String
        If millar Then
            unid = unid / 1000
            dece = dece / 1000
        End If
        Dim numero As Integer = unid + dece
        If numero = 11 Then
            Return "ONCE"
        ElseIf numero = 12 Then
            Return "DOCE"
        ElseIf numero = 13 Then
            Return "TRECE"
        ElseIf numero = 14 Then
            Return "CATORCE"
        ElseIf numero = 15 Then
            Return "QUINCE"
        ElseIf numero = 16 Then
            Return "DIECISEIS"
        ElseIf numero = 17 Then
            Return "DIECISIETE"
        ElseIf numero = 18 Then
            Return "DIECIOCHO"
        ElseIf numero = 19 Then
            Return "DIECINUEVE"
        ElseIf numero = 21 Then
            Return "VEINTIUN"
        ElseIf numero = 22 Then
            Return "VEINTIDOS"
        ElseIf numero = 23 Then
            Return "VEINTITRES"
        ElseIf numero = 24 Then
            Return "VEINTICUATRO"
        ElseIf numero = 25 Then
            Return "VEINTICINCO"
        ElseIf numero = 26 Then
            Return "VEINTISEIS"
        ElseIf numero = 27 Then
            Return "VEINTISIETE"
        ElseIf numero = 28 Then
            Return "VEINTIOCHO"
        ElseIf numero = 29 Then
            Return "VEINTINUEVE"
        End If
        Return ""
    End Function
End Module