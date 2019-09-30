Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Module mod_Encrypt

    ' Decript And Encript
    ''Dim plainText As String
    ''Dim cipherText As String = ""

    'Dim passPhrase As String         ' can be any string
    Public DinamicKey As String          ' can be any string
    Dim saltValue As String         ' can be any string
    Dim hashAlgorithm As String              ' can be "MD5"
    Dim passwordIterations As Integer                   ' can be any number
    Dim initVector As String  ' must be 16 bytes
    Dim keySize As Integer                 ' can be 192 or 128

    Public pathway As String ' encrript way

    Public Sub MCcase()
        'cipherText = ""
        If pathway = "freeway" Then
            DinamicKey = "Pas5pr@se"        ' can be any string
            saltValue = "s@1tValue"        ' can be any string
            hashAlgorithm = "SHA1"             ' can be "MD5"
            passwordIterations = 2                  ' can be any number
            initVector = "@1B2c3D4e5F6g7H8" ' must be 16 bytes
            keySize = 256                ' can be 192 or 128
        ElseIf pathway = "macway" Then
            ' DinamicKey = "1Pas5pr@se"        ' can be any string
            saltValue = "1s@1tValue"        ' can be any string
            hashAlgorithm = "SHA1"             ' can be "MD5"
            passwordIterations = 3                  ' can be any number
            initVector = "@2B2c3D4e5F6g7H8" ' must be 16 bytes
            keySize = 256                ' can be 192 or 1288
        ElseIf pathway = "sendcust" Then
            DinamicKey = "2Pas5pr@se"        ' can be any string
            saltValue = "2s@1tValue"        ' can be any string
            hashAlgorithm = "SHA1"             ' can be "MD5"
            passwordIterations = 4                  ' can be any number
            initVector = "@2B4c3D4e5F6g7H8" ' must be 16 bytes
            keySize = 256                ' can be 192 or 1288
        End If
    End Sub

    Public Function encrip(ByVal plainText As String)
        MCcase()
        Dim encripted As String
        '' ''passPhrase = "Pas5pr@se"        ' can be any string
        '' ''saltValue = "s@1tValue"        ' can be any string
        '' ''hashAlgorithm = "SHA1"             ' can be "MD5"
        '' ''passwordIterations = 2                  ' can be any number
        '' ''initVector = "@1B2c3D4e5F6g7H8" ' must be 16 bytes
        '' ''keySize = 256                ' can be 192 or 128

        '  Console.WriteLine(String.Format("Plaintext : {0}", plainText))

        encripted = RijndaelSimple.Encrypt(plainText, _
                                            DinamicKey, _
                                            saltValue, _
                                            hashAlgorithm, _
                                            passwordIterations, _
                                            initVector, _
                                            keySize)

        encrip = (String.Format(encripted))
        'Console.WriteLine(String.Format("Encrypted : {0}", cipherText))

    End Function


    Public Function decrip(ByVal cipherText As String)
        MCcase()
        Dim Decripted As String

        '' ''passPhrase = "Pas5pr@se"        ' can be any string
        '' ''saltValue = "s@1tValue"        ' can be any string
        '' ''hashAlgorithm = "SHA1"             ' can be "MD5"
        '' ''passwordIterations = 2                  ' can be any number
        '' ''initVector = "@1B2c3D4e5F6g7H8" ' must be 16 bytes
        '' ''keySize = 256                ' can be 192 or 128

        ' Console.WriteLine(String.Format("Plaintext : {0}", plainText))

        Decripted = RijndaelSimple.Decrypt(cipherText, _
                                            DinamicKey, _
                                            saltValue, _
                                            hashAlgorithm, _
                                            passwordIterations, _
                                            initVector, _
                                            keySize)

        decrip = Decripted
        'Console.WriteLine(String.Format("Decrypted : {0}", plainText))Decripted
    End Function
End Module
