Imports System
Imports System.Runtime.Intrinsics.X86

Module Program
    Sub Main(args As String())
        Console.WriteLine("Tarea")
        Console.WriteLine("Digite una cantidad entre 0 y 99999: ")
        Dim cantidad As Double = Single.Parse(Console.ReadLine())

        Console.WriteLine("La cantidad en numero es: " & cantidad)

        Dim centavos As Double = cantidad Mod 1
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
        Console.WriteLine("Decenas: " & decenas)
        Console.WriteLine("Centenas: " & centenas)
        Console.WriteLine("Unidades de Millar: " & unidadesMillar)
        Console.WriteLine("Decenas de Millar: " & decenasMillar)
        Dim unidadestxt As String = NombreUnidades(unidades)
        Dim decenastxt As String = NombreDecenas(decenas)
        Dim centenastxt As String = NombreCentenas(centenas)
        Dim unidadesMillartxt As String = NombreUnidadesMillar(unidadesMillar)
        Dim decenasMillartxt As String = NombreDecenasMillar(decenasMillar)
        Console.WriteLine("Unidades en texto: " & unidadestxt)
        Console.WriteLine("Decenas en texto: " & decenastxt)
        Console.WriteLine("Centenas en texto: " & centenastxt)
        Console.WriteLine("Unidades de Millar en texto: " & unidadesMillartxt)
        Console.WriteLine("Decenas de Millar en texto: " & decenasMillartxt)
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
End Module