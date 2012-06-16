Imports RegawMOD.Android
Public Class Form1
    Dim android As AndroidController
    Dim device As Device
    Dim model As String
    Dim version As String
    Dim failedRemount As Boolean
    Public Sub Delay(ByVal dblSecs As Double)
        Const OneSec As Double = 1.0# / (1440.0# * 60.0#)
        Dim dblWaitTil As Date
        Now.AddSeconds(OneSec)
        dblWaitTil = Now.AddSeconds(OneSec).AddSeconds(dblSecs)
        Do Until Now > dblWaitTil
            Application.DoEvents() ' Allow windows messages to be processed
        Loop
    End Sub
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
        android = AndroidController.Instance
    End Sub
    Private Sub Form1_Close(sender As System.Object, e As System.EventArgs) Handles Me.FormClosing
        android.Dispose()
    End Sub
    Public Sub reboot()
        Dim reboot As AdbCommand = Adb.FormAdbCommand("reboot")
        Adb.ExecuteAdbCommandNoReturn(reboot)
    End Sub
    Public Sub remount()
        Dim remount As AdbCommand = Adb.FormAdbCommand("remount")
        If Adb.ExecuteAdbCommand(remount).Contains("remount failed") Then
            failedRemount = True
        Else
            failedRemount = False
        End If
    End Sub
    Public Sub esteemUnroot()
        Dim bootLogo As AdbCommand = Adb.FormAdbShellCommand(device, False, "rm", "/data/bootlogo/bootlogopid")
        Dim bootLogo2 As AdbCommand = Adb.FormAdbShellCommand(device, False, "ln", "-s /data /data/bootlogo/bootlogopid")
        Dim localProp As AdbCommand = Adb.FormAdbShellCommand(device, False, "echo", "'ro.kernel.qemu=1' > /data/local.prop")
        Dim cleanUp As AdbCommand = Adb.FormAdbShellCommand(device, False, "rm", "/data/bootlogo/bootlogopid")
        Dim cleanUp2 As AdbCommand = Adb.FormAdbShellCommand(device, False, "rm", "/data/local.prop")
        TextBox1.Text += "Pwning Root stage 1" + vbCrLf
        Adb.ExecuteAdbCommandNoReturn(bootLogo)
        Adb.ExecuteAdbCommandNoReturn(bootLogo2)
        TextBox1.Text += "Rebooting" + vbCrLf
        reboot()
        TextBox1.Text += "Waiting for device" + vbCrLf
        android.WaitForDevice()
        TextBox1.Text += "Pwning Root stage 2" + vbCrLf
        Adb.ExecuteAdbCommandNoReturn(localProp)
        TextBox1.Text += "Rebooting again..." + vbCrLf
        reboot()
        TextBox1.Text += "Waiting for device" + vbCrLf
        android.WaitForDevice()
        TextBox1.Text += "Remounting System" + vbCrLf
        remount()
        If failedRemount = False Then
            Dim rmBBox As AdbCommand = Adb.FormAdbShellCommand(device, False, "rm", "/system/bin/busybox")
            Dim rmBB As AdbCommand = Adb.FormAdbShellCommand(device, False, "rm", "/system/xbin/busybox")
            Dim rmSu As AdbCommand = Adb.FormAdbShellCommand(device, False, "rm", "/system/bin/su")
            Dim rmSuAPK As AdbCommand = Adb.FormAdbShellCommand(device, False, "rm", "/system/app/Superuser.apk")
            Adb.ExecuteAdbCommandNoReturn(rmBB)
            Adb.ExecuteAdbCommandNoReturn(rmBBox)
            Adb.ExecuteAdbCommandNoReturn(rmSu)
            Adb.ExecuteAdbCommandNoReturn(rmSuAPK)
            Adb.ExecuteAdbCommandNoReturn(cleanUp)
            Adb.ExecuteAdbCommandNoReturn(cleanUp2)
        Else
            TextBox1.Text += "I have failed to remount your system partition please try again" + vbCrLf
        End If
    End Sub
    Public Sub SpecUnroot()
        Dim gpsEnv As AdbCommand = Adb.FormAdbShellCommand(device, False, "rm", "/data/gpscfg/gps_env.conf 2>/dev/null")
        Dim gpsEnv2 As AdbCommand = Adb.FormAdbShellCommand(device, False, "ln", "-s /data /data/gpscfg/gps_env.conf")
        Dim localProp As AdbCommand = Adb.FormAdbShellCommand(device, False, "echo", "'ro.kernel.qemu=1' > /data/local.prop")
        Dim cleanUp As AdbCommand = Adb.FormAdbShellCommand(device, False, "rm", "/data/local.prop")
        Dim cleanUp2 As AdbCommand = Adb.FormAdbShellCommand(device, False, "rm", "/data/gpscfg/*")
        Dim cleanUp3 As AdbCommand = Adb.FormAdbShellCommand(device, False, "chmod", "771 /data")
        TextBox1.Text += "Pwning Root stage 1" + vbCrLf
        Adb.ExecuteAdbCommandNoReturn(gpsEnv)
        Adb.ExecuteAdbCommandNoReturn(gpsEnv2)
        TextBox1.Text += "Rebooting" + vbCrLf
        reboot()
        TextBox1.Text += "Waiting for device" + vbCrLf
        android.WaitForDevice()
        TextBox1.Text += "Pwning Root stage 2" + vbCrLf
        Adb.ExecuteAdbCommandNoReturn(localProp)
        TextBox1.Text += "Rebooting again..." + vbCrLf
        reboot()
        TextBox1.Text += "Waiting for device" + vbCrLf
        android.WaitForDevice()
        TextBox1.Text += "Remounting System" + vbCrLf
        remount()
        If failedRemount = False Then
            Dim rmBBox As AdbCommand = Adb.FormAdbShellCommand(device, False, "rm", "/system/bin/busybox")
            Dim rmBB As AdbCommand = Adb.FormAdbShellCommand(device, False, "rm", "/system/xbin/busybox")
            Dim rmSu As AdbCommand = Adb.FormAdbShellCommand(device, False, "rm", "/system/bin/su")
            Dim rmSuAPK As AdbCommand = Adb.FormAdbShellCommand(device, False, "rm", "/system/app/Superuser.apk")
            Adb.ExecuteAdbCommandNoReturn(rmBB)
            Adb.ExecuteAdbCommandNoReturn(rmBBox)
            Adb.ExecuteAdbCommandNoReturn(rmSu)
            Adb.ExecuteAdbCommandNoReturn(rmSuAPK)
            Adb.ExecuteAdbCommandNoReturn(cleanUp)
            Adb.ExecuteAdbCommandNoReturn(cleanUp2)
            Adb.ExecuteAdbCommandNoReturn(cleanUp3)
        Else
            TextBox1.Text += "I have failed to remount your system partition please try again" + vbCrLf
        End If
    End Sub
    Public Sub specRoot()
        Dim busyBox As AdbCommand = Adb.FormAdbCommand("push", "busybox /system/xbin/busybox")
        Dim suBin As AdbCommand = Adb.FormAdbCommand("push", "su /system/bin/su")
        Dim superApk As AdbCommand = Adb.FormAdbCommand("push", "Superuser.apk /system/app/Superuser.apk")
        Dim gpsEnv As AdbCommand = Adb.FormAdbShellCommand(device, False, "rm", "/data/gpscfg/gps_env.conf 2>/dev/null")
        Dim gpsEnv2 As AdbCommand = Adb.FormAdbShellCommand(device, False, "ln", "-s /data /data/gpscfg/gps_env.conf")
        Dim localProp As AdbCommand = Adb.FormAdbShellCommand(device, False, "echo", "'ro.kernel.qemu=1' > /data/local.prop")
        Dim cleanUp As AdbCommand = Adb.FormAdbShellCommand(device, False, "rm", "/data/local.prop")
        Dim cleanUp2 As AdbCommand = Adb.FormAdbShellCommand(device, False, "rm", "/data/gpscfg/*")
        Dim cleanUp3 As AdbCommand = Adb.FormAdbShellCommand(device, False, "chmod", "771 /data")
        TextBox1.Text += "Pwning Root stage 1" + vbCrLf
        Adb.ExecuteAdbCommandNoReturn(gpsEnv)
        Adb.ExecuteAdbCommandNoReturn(gpsEnv2)
        TextBox1.Text += "Rebooting" + vbCrLf
        reboot()
        TextBox1.Text += "Waiting for device" + vbCrLf
        android.WaitForDevice()
        TextBox1.Text += "Pwning Root stage 2" + vbCrLf
        Adb.ExecuteAdbCommandNoReturn(localProp)
        TextBox1.Text += "Rebooting again..." + vbCrLf
        reboot()
        TextBox1.Text += "Waiting for device" + vbCrLf
        android.WaitForDevice()
        TextBox1.Text += "Remounting System" + vbCrLf
        remount()
        If failedRemount = False Then
            TextBox1.Text += "Installing Root files" + vbCrLf
            Dim suMod As AdbCommand = Adb.FormAdbShellCommand(device, False, "chmod", "6755 /system/bin/su")
            Dim suLn As AdbCommand = Adb.FormAdbShellCommand(device, False, "ln", "-s /system/bin/su /system/xbin/su")
            Dim bbInstall As AdbCommand = Adb.FormAdbShellCommand(device, False, "/system/xbin/busybox", "--install /system/xbin")
            Dim bbMod As AdbCommand = Adb.FormAdbShellCommand(device, False, "chmod", "755 /system/xbin/busybox")
            Adb.ExecuteAdbCommandNoReturn(suBin)
            Adb.ExecuteAdbCommandNoReturn(suMod)
            Adb.ExecuteAdbCommandNoReturn(suLn)
            Adb.ExecuteAdbCommandNoReturn(superApk)
            Adb.ExecuteAdbCommandNoReturn(busyBox)
            Adb.ExecuteAdbCommandNoReturn(bbMod)
            Adb.ExecuteAdbCommandNoReturn(bbInstall)
            TextBox1.Text += "Cleaning up the mess" + vbCrLf
            Adb.ExecuteAdbCommandNoReturn(cleanUp)
            Adb.ExecuteAdbCommandNoReturn(cleanUp2)
            Adb.ExecuteAdbCommand(cleanUp3)
        Else
            TextBox1.Text += "I have failed to remount your system partition please try again" + vbCrLf
        End If
    End Sub
    Public Sub esteemRoot()
        Dim busyBox As AdbCommand = Adb.FormAdbCommand("push", "busybox /system/xbin/busybox")
        Dim suBin As AdbCommand = Adb.FormAdbCommand("push", "su /system/bin/su")
        Dim superApk As AdbCommand = Adb.FormAdbCommand("push", "Superuser.apk /system/app/Superuser.apk")
        Dim bootLogo As AdbCommand = Adb.FormAdbShellCommand(device, False, "rm", "/data/bootlogo/bootlogopid")
        Dim bootLogo2 As AdbCommand = Adb.FormAdbShellCommand(device, False, "ln", "-s /data /data/bootlogo/bootlogopid")
        Dim localProp As AdbCommand = Adb.FormAdbShellCommand(device, False, "echo", "'ro.kernel.qemu=1' > /data/local.prop")
        Dim cleanUp As AdbCommand = Adb.FormAdbShellCommand(device, False, "rm", "/data/bootlogo/bootlogopid")
        Dim cleanUp2 As AdbCommand = Adb.FormAdbShellCommand(device, False, "rm", "/data/local.prop")
        TextBox1.Text += "Pwning Root stage 1" + vbCrLf
        Adb.ExecuteAdbCommandNoReturn(bootLogo)
        Adb.ExecuteAdbCommandNoReturn(bootLogo2)
        TextBox1.Text += "Rebooting" + vbCrLf
        reboot()
        TextBox1.Text += "Waiting for device" + vbCrLf
        android.WaitForDevice()
        TextBox1.Text += "Pwning Root stage 2" + vbCrLf
        Adb.ExecuteAdbCommandNoReturn(localProp)
        TextBox1.Text += "Rebooting again..." + vbCrLf
        reboot()
        TextBox1.Text += "Waiting for device" + vbCrLf
        android.WaitForDevice()
        TextBox1.Text += "Remounting System" + vbCrLf
        remount()
        If failedRemount = False Then
            TextBox1.Text += "Installing Root files" + vbCrLf
            Dim suMod As AdbCommand = Adb.FormAdbShellCommand(device, False, "chmod", "6755 /system/bin/su")
            Dim suLn As AdbCommand = Adb.FormAdbShellCommand(device, False, "ln", "-s /system/bin/su /system/xbin/su")
            Dim bbInstall As AdbCommand = Adb.FormAdbShellCommand(device, False, "/system/xbin/busybox", "--install /system/xbin")
            Dim bbMod As AdbCommand = Adb.FormAdbShellCommand(device, False, "chmod", "755 /system/xbin/busybox")
            Adb.ExecuteAdbCommandNoReturn(suBin)
            Adb.ExecuteAdbCommandNoReturn(suMod)
            Adb.ExecuteAdbCommandNoReturn(suLn)
            Adb.ExecuteAdbCommandNoReturn(superApk)
            Adb.ExecuteAdbCommandNoReturn(busyBox)
            Adb.ExecuteAdbCommandNoReturn(bbMod)
            Adb.ExecuteAdbCommandNoReturn(bbInstall)
            TextBox1.Text += "Cleaning up the mess" + vbCrLf
            Adb.ExecuteAdbCommandNoReturn(cleanUp)
            Adb.ExecuteAdbCommandNoReturn(cleanUp2)
        Else
            TextBox1.Text += "I have failed to remount your system partition please try again" + vbCrLf
        End If
    End Sub
    Public Sub cwm()
        Dim cwmPushRevo As AdbCommand = Adb.FormAdbCommand("push", "revocwm.img /data/local/tmp/revocwm.img")
        Dim revoBackup As AdbCommand = Adb.FormAdbShellCommand(device, False, "dd", "if=/dev/block/mmcblk0p14 of=/sdcard/mmcblk0p14.backup")
        Dim cwmFlashRevo As AdbCommand = Adb.FormAdbShellCommand(device, False, "dd", "if=/data/local/tmp/revocwm.img of=/dev/block/mmcblk0p14")
        Dim cwmPushLucid As AdbCommand = Adb.FormAdbCommand("push", "lucidcwm.img /data/local/tmp/lucidcwm.img")
        Dim lucidBackup As AdbCommand = Adb.FormAdbShellCommand(device, False, "dd", "if=/dev/block/mmcblk0p13 of=/sdcard/mmcblk0p13.backup")
        Dim cwmFlashLucid As AdbCommand = Adb.FormAdbShellCommand(device, False, "dd", "if=/data/local/tmp/lucidcwm.img of=/dev/block/mmcblk0p13")
        Dim cwmPushSpec As AdbCommand = Adb.FormAdbCommand("push", "speccwm.img /data/local/tmp/speccwm.img")
        Dim SpecBackup As AdbCommand = Adb.FormAdbShellCommand(device, False, "dd", "if=/dev/block/mmcblk0p13 of=/sdcard/mmcblk0p13.backup")
        Dim cwmFlashSpec As AdbCommand = Adb.FormAdbShellCommand(device, False, "dd", "if=/data/local/tmp/speccwm.img of=/dev/block/mmcblk0p13")
        Dim mvRecsh As AdbCommand = Adb.FormAdbShellCommand(device, False, "mv", "/system/etc/install-recovery.sh /system/etc/install-recovery.sh.bak")
        If model = "VS910 4G" Then
            TextBox1.Text += "Remounting System" + vbCrLf
            remount()
            If device.BuildProp.GetProp("ro.build.version.incremental").Contains("ZV9") Then
                Adb.ExecuteAdbCommand(mvRecsh)
            End If
            TextBox1.Text += "Pushing Recovery Files" + vbCrLf
            TextBox1.Text += Adb.ExecuteAdbCommand(cwmPushRevo) + vbCrLf
            TextBox1.Text += "Backing up Original Recovery" + vbCrLf
            TextBox1.Text += Adb.ExecuteAdbCommand(revoBackup) + vbCrLf
            TextBox1.Text += "Flashing CWM Recovery" + vbCrLf
            TextBox1.Text += Adb.ExecuteAdbCommand(cwmFlashRevo) + vbCrLf
            TextBox1.Text += "Rebooting into CWM" + vbCrLf
            device.RebootRecovery()
        ElseIf model = "VS840 4G" Then
            If device.HasRoot Then
                TextBox1.Text += "Remounting System" + vbCrLf
                remount()
                TextBox1.Text += "Pushing Recovery Files" + vbCrLf
                TextBox1.Text += Adb.ExecuteAdbCommand(cwmPushLucid) + vbCrLf
                TextBox1.Text += "Backing up Original Recovery" + vbCrLf
                TextBox1.Text += Adb.ExecuteAdbCommand(lucidBackup) + vbCrLf
                TextBox1.Text += "Flashing CWM Recovery" + vbCrLf
                TextBox1.Text += Adb.ExecuteAdbCommand(cwmFlashLucid) + vbCrLf
                TextBox1.Text += "Rebooting into CWM" + vbCrLf
                device.RebootRecovery()
            Else
                PictureBox1.Image = My.Resources.root
            End If
        ElseIf model = "VS920 4G" Then
            If device.HasRoot Then
                TextBox1.Text += "Remounting System" + vbCrLf
                remount()
                TextBox1.Text += "Pushing Recovery Files" + vbCrLf
                TextBox1.Text += Adb.ExecuteAdbCommand(cwmPushSpec) + vbCrLf
                TextBox1.Text += "Backing up Original Recovery" + vbCrLf
                TextBox1.Text += Adb.ExecuteAdbCommand(SpecBackup) + vbCrLf
                TextBox1.Text += "Flashing CWM Recovery" + vbCrLf
                TextBox1.Text += Adb.ExecuteAdbCommand(cwmFlashSpec) + vbCrLf
                TextBox1.Text += "Rebooting into CWM" + vbCrLf
                device.RebootRecovery()
            Else
                PictureBox1.Image = My.Resources.root
            End If
        Else
            TextBox1.Text += "Sorry your device isnt supported at this time." & vbCrLf
        End If
    End Sub
    Public Sub modelNum()
        model = device.BuildProp.GetProp("ro.product.model")
        version = device.BuildProp.GetProp("ro.build.version.incremental")
        PictureBox1.Show()
        If model = "VS910 4G" Then
            Label1.Text = "LG Revolution 4G"
            Label2.Text = version
            PictureBox1.Image = My.Resources.lg_revolution_review
        ElseIf model = "VS840 4G" Then
            Label1.Text = "LG Lucid 4G"
            Label2.Text = version
            PictureBox1.Image = My.Resources._286284_lg_lucid_verizon_wireless
        ElseIf model = "VS920 4G" Then
            Label1.Text = "LG Spectrum 4G"
            Label2.Text = version
            PictureBox1.Image = My.Resources.LG_Spectrum
        Else
            TextBox1.Text += "Sorry your device isnt supported at this time." + vbCrLf
        End If
    End Sub
    Private Sub rootButton_Click(sender As System.Object, e As System.EventArgs) Handles rootButton.Click
        Try
            deviceList()
            modelNum()
            If model = "VS920 4G" Then
                specRoot()
            Else
                esteemRoot()
            End If
            reboot()
            android.WaitForDevice()
            Delay(15)
            deviceList()
            If device.HasRoot Then
                TextBox1.Text += "You have successfully pwned your LG Device enjoy" + vbCrLf
            Else
                TextBox1.Text += "You haz failed to acquire root please try again" + vbCrLf
            End If
        Catch x As Exception
            PictureBox1.Image = My.Resources._1532___epic_fail_star_wars
        End Try
    End Sub

    Private Sub cmwButton_Click(sender As System.Object, e As System.EventArgs) Handles cwmButton.Click
        Try
            deviceList()
            modelNum()
            cwm()
        Catch x As Exception
            PictureBox1.Image = My.Resources._1532___epic_fail_star_wars
        End Try
    End Sub

    Private Sub rootCWMButton_Click(sender As System.Object, e As System.EventArgs) Handles rootCWMButton.Click
        Try
            deviceList()
            modelNum()
            If model = "VS920 4G" Then
                specRoot()
            Else
                esteemRoot()
            End If
            cwm()
            android.WaitForDevice()
            Delay(30)
            deviceList()
            If device.HasRoot Then
                If DeviceState.RECOVERY Then
                    TextBox1.Text += "Your device has been successfully pwned"
                Else
                    TextBox1.Text += "Your device has failed to be pwned please try again"
                End If
            End If
        Catch x As Exception
            PictureBox1.Image = My.Resources._1532___epic_fail_star_wars
        End Try
    End Sub

    Private Sub unroot_Click(sender As System.Object, e As System.EventArgs) Handles unroot.Click
        deviceList()
        modelNum()
        If model = "VS920 4G" Then
            SpecUnroot()
        Else
            esteemUnroot()
        End If
        Delay(30)
        Dim cwmPushRevo As AdbCommand = Adb.FormAdbCommand("push", "revostock.img /data/local/tmp/revostock.img")
        Dim revoBackup As AdbCommand = Adb.FormAdbShellCommand(device, False, "dd", "if=/dev/block/mmcblk0p14 of=/sdcard/mmcblk0p14.backup2")
        Dim cwmFlashstockRevo As AdbCommand = Adb.FormAdbShellCommand(device, False, "dd", "if=/data/local/tmp/revostock.img of=/dev/block/mmcblk0p14")
        Dim cwmPushLucid As AdbCommand = Adb.FormAdbCommand("push", "lucidstock.img /data/local/tmp/lucidstock.img")
        Dim lucidBackup As AdbCommand = Adb.FormAdbShellCommand(device, False, "dd", "if=/dev/block/mmcblk0p13 of=/sdcard/mmcblk0p13.backup2")
        Dim cwmFlashstockLucid As AdbCommand = Adb.FormAdbShellCommand(device, False, "dd", "if=/data/local/tmp/lucidstock.img of=/dev/block/mmcblk0p13")
        Dim cwmPushSpec As AdbCommand = Adb.FormAdbCommand("push", "specstock.img /data/local/tmp/specstock.img")
        Dim SpecBackup As AdbCommand = Adb.FormAdbShellCommand(device, False, "dd", "if=/dev/block/mmcblk0p13 of=/sdcard/mmcblk0p13.backup2")
        Dim cwmFlashstockSpec As AdbCommand = Adb.FormAdbShellCommand(device, False, "dd", "if=/data/local/tmp/specstock.img of=/dev/block/mmcblk0p13")
        If model = "VS910 4G" Then
            TextBox1.Text += "Pushing Recovery Files" + vbCrLf
            TextBox1.Text += Adb.ExecuteAdbCommand(cwmPushRevo) + vbCrLf
            TextBox1.Text += "Backing up Recovery" + vbCrLf
            TextBox1.Text += Adb.ExecuteAdbCommand(revoBackup) + vbCrLf
            TextBox1.Text += "Flashing Stock Recovery" + vbCrLf
            TextBox1.Text += Adb.ExecuteAdbCommand(cwmFlashstockRevo) + vbCrLf
            reboot()
        ElseIf model = "VS840 4G" Then
            TextBox1.Text += "Pushing Recovery Files" + vbCrLf
            TextBox1.Text += Adb.ExecuteAdbCommand(cwmPushLucid) + vbCrLf
            TextBox1.Text += "Backing up Recovery" + vbCrLf
            TextBox1.Text += Adb.ExecuteAdbCommand(lucidBackup) + vbCrLf
            TextBox1.Text += "Flashing Stock Recovery" + vbCrLf
            TextBox1.Text += Adb.ExecuteAdbCommand(cwmFlashstockLucid) + vbCrLf
            reboot()
        ElseIf model = "VS920 4G" Then
            TextBox1.Text += "Pushing Recovery Files" + vbCrLf
            TextBox1.Text += Adb.ExecuteAdbCommand(cwmPushSpec) + vbCrLf
            TextBox1.Text += "Backing upOriginal Recovery" + vbCrLf
            TextBox1.Text += Adb.ExecuteAdbCommand(SpecBackup) + vbCrLf
            TextBox1.Text += "Flashing Stock Recovery" + vbCrLf
            TextBox1.Text += Adb.ExecuteAdbCommand(cwmFlashstockSpec) + vbCrLf
            reboot()
            android.WaitForDevice()
            deviceList()
            If device.HasRoot Then
                TextBox1.Text += "Your device has not been unrooted" + vbCrLf
            Else
                TextBox1.Text += "Your device has been unrooted and stock recovery restored" + vbCrLf
            End If
        Else
            TextBox1.Text += "Sorry your device isnt supported at this time." & vbCrLf
        End If
    End Sub
    Public Sub deviceList()
        Try
            Dim serial As String
            'Always call UpdateDeviceList() before using AndroidController on devices to get the most updated list
            android.UpdateDeviceList()
            If (android.HasConnectedDevices) Then
                serial = android.ConnectedDevices(0)
                device = android.GetConnectedDevice(serial)
            Else
                TextBox1.Text += "Error - No Devices Connected" + vbCrLf
            End If
        Catch x As Exception
            PictureBox1.Image = My.Resources._1532___epic_fail_star_wars
        End Try
    End Sub
End Class
