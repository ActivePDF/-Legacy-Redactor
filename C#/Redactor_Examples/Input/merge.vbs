
' Copyright (c) 2019 ActivePDF, Inc.
' ActivePDF Toolkit 2018
' Example generated 05/01/19 

Dim FSO, strPath, intOpenOutputFile, intMergeFile

' Get current path
Set FSO = CreateObject("Scripting.FileSystemObject")
strPath = FSO.GetFile(Wscript.ScriptFullName).ParentFolder & "\"
Set FSO = Nothing

' Instantiate Object
Set oTK = CreateObject("APToolkit.Object")

' Create the new PDF file
intOpenOutputFile = oTK.OpenOutputFile(strPath & "new.pdf")
If intOpenOutputFile <> 0 Then
  ErrorHandler "OpenOutputFile", intOpenOutputFile
End If

' Set whether the fields should be read only in the output PDF
' 0 leave fields as they are, 1 mark all fields as read-only
' Fields set with SetFormFieldData will not be effected
oTK.ReadOnlyOnMerge = 1

' MergeFile is the equivalent of OpenInputFile and CopyForm

' Merge the cover page (0 for all pages)
intMergeFile = oTK.MergeFile(strPath & "Xtractor.Input.pdf", 1, 1)
If intMergeFile <> 1 Then
  ErrorHandler "MergeFile", intMergeFile
End If

' Merge the second PDF
intMergeFile = oTK.MergeFile(strPath & "RedactorDS_201805.pdf", 0, 0)
If intMergeFile <> 1 Then
  ErrorHandler "MergeFile", intMergeFile
End If

' Close the new file to complete PDF creation
oTK.CloseOutputFile 

' Release Object
Set oTK = Nothing

' Process Complete
Wscript.Echo("Done!")

' Error Handling
Sub ErrorHandler(method, outputCode)
  Wscript.Echo("Error in " & method & ": " & outputCode)
End Sub