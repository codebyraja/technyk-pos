Imports System.Windows.Forms
Imports System.Drawing
Imports System.Linq

Public Module UIHelper

    Public Sub AdjustHeaderDynamic(form As Form,
                                          headerPanel As Panel,
                                          logo As PictureBox,
                                          rightButtons As List(Of Button),
                                          leftButtons As List(Of Button),
                                          titleLabel As Label,
                                          subtitleLabel As Label)

        If form Is Nothing OrElse headerPanel Is Nothing Then Exit Sub

        'Dim screenHeight As Integer = Screen.FromControl(form).WorkingArea.Height
        Dim screenHeight As Integer = Screen.GetWorkingArea(form).Height

        Dim scaleFactor As Double = screenHeight / 1080.0

        Dim headerHeight As Integer = CInt(72 * scaleFactor)
        If headerHeight < 55 Then headerHeight = 55
        If headerHeight > 100 Then headerHeight = 100
        'headerHeight = Math.Max(55, Math.Min(100, headerHeight))
        headerPanel.Height = headerHeight

        Dim buttonSize As Integer = CInt(40 * scaleFactor)
        If buttonSize < 28 Then buttonSize = 28
        If buttonSize > 55 Then buttonSize = 55

        Dim logoSize As Integer = CInt(55 * scaleFactor)
        If logoSize < 35 Then logoSize = 35
        If logoSize > 75 Then logoSize = 75

        ' Logo
        logo.SizeMode = PictureBoxSizeMode.Zoom
        logo.Width = logoSize
        logo.Height = logoSize
        logo.Margin = New Padding(10, 0, 10, 0)
        logo.Anchor = AnchorStyles.None
        'logo.Margin = New Padding(10, (headerHeight - logoSize) \ 2, 10, 0)

        ' ===== Buttons =====
        Dim allButtons As New List(Of Button)
        allButtons.AddRange(rightButtons)
        allButtons.AddRange(leftButtons)

        For Each btn In allButtons
            btn.Size = New Size(buttonSize, buttonSize)
            btn.BackgroundImageLayout = ImageLayout.Zoom
            btn.Margin = New Padding(8, 0, 8, 0)
            btn.Anchor = AnchorStyles.None
        Next

        ' Buttons
        'For Each btn In rightButtons.Concat(leftButtons)
        '    btn.Width = buttonSize
        '    btn.Height = buttonSize
        '    btn.BackgroundImageLayout = ImageLayout.Zoom
        '    'btn.Margin = New Padding(5, (headerHeight - buttonSize) \ 2, 5, 0)
        '    btn.Margin = New Padding(8, 0, 8, 0)
        'Next

        ' Fonts scale
        Dim titleFontSize As Single = CSng(16 * scaleFactor)
        If titleFontSize < 12 Then titleFontSize = 12
        If titleFontSize > 24 Then titleFontSize = 24

        Dim subFontSize As Single = CSng(9 * scaleFactor)
        If subFontSize < 8 Then subFontSize = 8
        If subFontSize > 14 Then subFontSize = 14

        titleLabel.Font = New Font("Segoe UI", titleFontSize, FontStyle.Bold)
        subtitleLabel.Font = New Font("Segoe UI", subFontSize, FontStyle.Regular)
    End Sub

    Public Sub ApplyVerticalCentering(container As Control, headerPanel As Panel)

        If container Is Nothing OrElse headerPanel Is Nothing Then Exit Sub

        AddHandler container.Layout,
            Sub(sender As Object, e As LayoutEventArgs)

            Dim pnl As Control = DirectCast(sender, Control)

            For Each ctrl As Control In pnl.Controls
                ctrl.Margin = New Padding(8,
                                          (headerPanel.Height - ctrl.Height) \ 2,
                                          8,
                                          0)
            Next

        End Sub

    End Sub

    'Public Sub AdjustStatusStripDynamic(status As StatusStrip)

    '    If status Is Nothing Then Exit Sub

    '    status.AutoSize = False

    '    ' Screen height detect
    '    Dim screenHeight As Integer = Screen.FromControl(status).WorkingArea.Height

    '    Dim fontSize As Integer
    '    Dim stripHeight As Integer
    '    Dim iconSize As Integer
    '    Dim paddingSize As Integer

    '    If screenHeight >= 1440 Then
    '        stripHeight = 44
    '        fontSize = 11
    '        iconSize = 24
    '        paddingSize = 6
    '    ElseIf screenHeight >= 1080 Then
    '        stripHeight = 38
    '        fontSize = 10
    '        iconSize = 20
    '        paddingSize = 5
    '    ElseIf screenHeight >= 900 Then
    '        stripHeight = 32
    '        fontSize = 9
    '        iconSize = 18
    '        paddingSize = 4
    '    Else
    '        stripHeight = 26
    '        fontSize = 8
    '        iconSize = 16
    '        paddingSize = 3
    '    End If

    '    status.Height = stripHeight
    '    status.ImageScalingSize = New Size(iconSize, iconSize)

    '    Dim f As New Font("Segoe UI", fontSize, FontStyle.Regular)

    '    For Each item As ToolStripItem In status.Items

    '        item.Font = f
    '        item.Padding = New Padding(paddingSize, 0, paddingSize, 0)

    '        ' If item has image
    '        If item.Image IsNot Nothing Then
    '            item.ImageScaling = ToolStripItemImageScaling.SizeToFit
    '        End If

    '        ' Optional: increase minimum width proportionally
    '        If TypeOf item Is ToolStripStatusLabel Then
    '            item.AutoSize = True
    '        End If

    '    Next

    'End Sub

    Public Sub AdjustStatusStripDynamic(status As StatusStrip)

        If status Is Nothing Then Exit Sub

        status.SuspendLayout()

        status.AutoSize = False
        status.SizingGrip = False
        status.Dock = DockStyle.Bottom

        Dim screenHeight As Integer = Screen.FromControl(status).WorkingArea.Height

        Dim stripHeight As Integer
        Dim fontSize As Integer
        Dim iconSize As Integer

        If screenHeight >= 1440 Then
            stripHeight = 44
            fontSize = 11
            iconSize = 22
        ElseIf screenHeight >= 1080 Then
            stripHeight = 38
            fontSize = 10
            iconSize = 20
        ElseIf screenHeight >= 900 Then
            stripHeight = 32
            fontSize = 9
            iconSize = 18
        Else
            stripHeight = 26
            fontSize = 8
            iconSize = 16
        End If

        status.Height = stripHeight
        status.ImageScalingSize = New Size(iconSize, iconSize)

        Dim f As New Font("Segoe UI", fontSize, FontStyle.Regular)

        For Each item As ToolStripItem In status.Items

            item.Font = f
            item.Margin = New Padding(10, 0, 10, 0)
            item.TextAlign = ContentAlignment.MiddleLeft

            If item.Image IsNot Nothing Then
                item.ImageScaling = ToolStripItemImageScaling.SizeToFit
            End If

        Next

        status.ResumeLayout()

    End Sub
End Module