﻿Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports System.ComponentModel
'descargada de www.lamda-pi.net/encriptacion.vb
Public Class Encriptacion

    Public Shared Function Encriptar(ByVal InputString As String, ByVal SecretKey As String, Optional ByVal CyphMode As CipherMode = CipherMode.ECB) As String
        Dim Des As New TripleDESCryptoServiceProvider
        'Put the string into a byte array
        Dim InputbyteArray() As Byte = Encoding.UTF8.GetBytes(InputString)
        'Create the crypto objects, with the key, as passed in
        Dim hashMD5 As New MD5CryptoServiceProvider
        Des.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(SecretKey))
        Des.Mode = CyphMode
        Dim ms As MemoryStream = New MemoryStream
        Dim cs As CryptoStream = New CryptoStream(ms, Des.CreateEncryptor(), _
        CryptoStreamMode.Write)
        'Write the byte array into the crypto stream
        '(It will end up in the memory stream)
        cs.Write(InputbyteArray, 0, InputbyteArray.Length)
        cs.FlushFinalBlock()
        'Get the data back from the memory stream, and into a string
        Dim ret As StringBuilder = New StringBuilder
        Dim b() As Byte = ms.ToArray
        ms.Close()
        Dim I As Integer
        For I = 0 To UBound(b)
            'Format as hex
            ret.AppendFormat("{0:X2}", b(I))
        Next

        Return ret.ToString()

    End Function

    Public Shared Function DesEncriptar(ByVal InputString As String, ByVal SecretKey As String, Optional ByVal CyphMode As CipherMode = CipherMode.ECB) As String
        If InputString = String.Empty Then
            Return ""
        Else
            Dim Des As New TripleDESCryptoServiceProvider
            'Put the string into a byte array
            Dim InputbyteArray(CType(InputString.Length / 2 - 1, Integer)) As Byte '= Encoding.UTF8.GetBytes(InputString)
            'Create the crypto objects, with the key, as passed in
            Dim hashMD5 As New MD5CryptoServiceProvider

            Des.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(SecretKey))
            Des.Mode = CyphMode
            'Put the input string into the byte array

            Dim X As Integer

            For X = 0 To InputbyteArray.Length - 1
                Dim IJ As Int32 = (Convert.ToInt32(InputString.Substring(X * 2, 2), 16))
                Dim BT As New ByteConverter
                InputbyteArray(X) = New Byte
                InputbyteArray(X) = CType(BT.ConvertTo(IJ, GetType(Byte)), Byte)
            Next

            Dim ms As MemoryStream = New MemoryStream
            Dim cs As CryptoStream = New CryptoStream(ms, Des.CreateDecryptor(), _
            CryptoStreamMode.Write)

            'Flush the data through the crypto stream into the memory stream
            cs.Write(InputbyteArray, 0, InputbyteArray.Length)
            cs.FlushFinalBlock()

            '//Get the decrypted data back from the memory stream
            Dim ret As StringBuilder = New StringBuilder
            Dim B() As Byte = ms.ToArray

            ms.Close()

            Dim I As Integer

            For I = 0 To UBound(B)
                ret.Append(Chr(B(I)))
            Next

            Return ret.ToString()
        End If
    End Function

End Class