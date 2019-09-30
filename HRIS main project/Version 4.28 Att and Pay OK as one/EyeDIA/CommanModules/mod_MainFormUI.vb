'*********************************************************
'CREATE PROCEDURE TO MAINTAIN GUI DETAILS IN FORMS
'CREATE DATE    : 6/11/2016
'AUTHOR         : KASUN/Kasun
'PROJECT        : HRISforBB
'*********************************************************



Module mod_MainFormUI

    '*********** ATTENDANCE GUI SUMMARY RELATED VARIABLES **************
    Public dblGLBPrecent As Double = 0 : Public dblGLBAbsent As Double = 0 : Public dblGLBCadre As Double = 0
    Public dblGLBIncomplete As Double = 0 : Public dblGLBLeave As Double = 0 : Public dblGLBBirthDate As Double = 0
    Public dblGLBNewRecruit As Double = 0 : Public dblGLBResign As Double = 0

    '****************** END ********************************************

    Public Function fk_ChangeTopPanelColor() As Boolean

        frmMainAttendance.p1.BackColor = Color.FromArgb(247, 148, 28)
        frmMainAttendance.p2.BackColor = Color.FromArgb(22, 125, 62)
        frmMainAttendance.p3.BackColor = Color.FromArgb(47, 123, 191)
        frmMainAttendance.P4.BackColor = Color.FromArgb(224, 62, 68)
        frmMainAttendance.p5.BackColor = Color.FromArgb(146, 38, 143)
    End Function

    Public Function fk_attnSumValues(ByVal dtpGLBFrDate As Date, ByVal dtpGLBEdDate As Date) As Boolean

    End Function

End Module
