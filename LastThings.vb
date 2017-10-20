'locate last column 
'locate last row
'last things

Function lastCol(Optional strSheet As String, Optional rowToCheck As Long = 1) As Long

    Dim shSheet  As Worksheet
        If strSheet = vbNullString Then
            Set shSheet = ActiveSheet
        Else
            Set shSheet = Worksheets(strSheet)
        End If
    lastCol = shSheet.Cells(rowToCheck, shSheet.Columns.Count).End(xlToLeft).Column
End Function

Function lastRow(Optional strSheet As String, Optional column_to_check As Long = 1) As Long

    Dim shSheet As Worksheet

    If strSheet = vbNullString Then
        Set shSheet = ActiveSheet
    Else
        Set shSheet = Worksheets(strSheet)
    End If

    lastRow = shSheet.Cells(shSheet.Rows.Count, column_to_check).End(xlUp).Row

End Function
            
Public Function LastUsedColumn() As Long
    
    Dim rLastCell As Range
    
    Set rLastCell = ActiveSheet.Cells.Find(What:="*", _
                                    After:=ActiveSheet.Cells(1, 1), _
                                    LookIn:=xlFormulas, _
                                    LookAt:=xlPart, _
                                    SearchOrder:=xlByColumns, _
                                    SearchDirection:=xlPrevious, _
                                    MatchCase:=False)
    
    LastUsedColumn = rLastCell.Column

End Function

Public Function LastUsedRow() As Long

    Dim rLastCell As Range

    Set rLastCell = ActiveSheet.Cells.Find(What:="*", _
                                    After:=ActiveSheet.Cells(1, 1), _
                                    LookIn:=xlFormulas, _
                                    LookAt:=xlPart, _
                                    SearchOrder:=xlByRows, _
                                    SearchDirection:=xlPrevious, _
                                    MatchCase:=False)

    LastUsedRow = rLastCell.Row

End Function


'---------------------------------------------------------------------------------------
' Procedure : fnLngLocateValueRow
' Author    : v.doynov
' Date      : 16.03.2017
' Purpose   : blnLookUpToBottom is more powerful than lngMoreValuesFound and makes it useless.
'---------------------------------------------------------------------------------------
'
Public Function fnLngLocateValueRow(ByVal strTarget As String, _
    ByRef wksTarget As Worksheet, _
    Optional lngCol As Long = 1, _
    Optional lngMoreValuesFound As Long = 1, _
    Optional blnLookForPart = False, _
    Optional blnLookUpToBottom = True) As Long

    Dim lngValuesFound      As Long
    Dim rngLocal            As Range
    Dim rngMyCell           As Range

    fnLngLocateValueRow = -999
    lngValuesFound = lngMoreValuesFound
    Set rngLocal = wksTarget.Range(wksTarget.Cells(1, lngCol), wksTarget.Cells(Rows.Count, lngCol))

    For Each rngMyCell In rngLocal
        If blnLookForPart Then
            If strTarget = Left(rngMyCell, Len(strTarget)) Then
                If lngValuesFound = 1 Then
                    fnLngLocateValueRow = rngMyCell.row
                    If blnLookUpToBottom Then Exit Function
                Else
                    Call Decrement(lngValuesFound)
                End If
            End If
        Else
            If strTarget = Trim(rngMyCell) Then
                If lngValuesFound = 1 Then
                    fnLngLocateValueRow = rngMyCell.row
                    If blnLookUpToBottom Then Exit Function
                Else
                    Call Decrement(lngValuesFound)
                End If
            End If
        End If
    Next rngMyCell

End Function

'---------------------------------------------------------------------------------------
' Procedure : fnLngLocateValueCol
' Author    : v.doynov
' Date      : 16.03.2017
' Purpose   : blnLookUpToBottom is more powerful than lngMoreValuesFound and makes it useless.
'---------------------------------------------------------------------------------------
'
Public Function fnLngLocateValueCol(ByVal strTarget As String, _
    ByRef wksTarget As Worksheet, _
    Optional lngRow As Long = 1, _
    Optional lngMoreValuesFound As Long = 1, _
    Optional blnLookForPart = False, _
    Optional blnLookUpToBottom = True) As Long

    Dim lngValuesFound          As Long
    Dim rngLocal                As Range
    Dim rngMyCell               As Range

    fnLngLocateValueCol = -999
    lngValuesFound = lngMoreValuesFound
    Set rngLocal = wksTarget.Range(wksTarget.Cells(lngRow, 1), wksTarget.Cells(lngRow, Columns.Count))

    For Each rngMyCell In rngLocal
        If blnLookForPart Then
            If strTarget = Left(rngMyCell, Len(strTarget)) Then
                If lngValuesFound = 1 Then
                    fnLngLocateValueCol = rngMyCell.Column
                    If blnLookUpToBottom Then Exit Function
                Else
                    Call Decrement(lngValuesFound)
                End If
            End If
        Else
            If strTarget = Trim(rngMyCell) Then
                If lngValuesFound = 1 Then
                    fnLngLocateValueCol = rngMyCell.Column
                    If blnLookUpToBottom Then Exit Function
                Else
                    Call Decrement(lngValuesFound)
                End If
            End If
        End If
    Next rngMyCell

End Function
