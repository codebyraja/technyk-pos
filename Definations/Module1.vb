Option Strict Off
Option Explicit On 
Module ACR120U
    '=========================================================================================
    '
    '   Company:  Advanced Card Systems LTD.
    '
    '   Module :  ACR120U API
    '
    '   Author :  Richard C. Siman
    '
    '   Date   :  August 8, 2005
    '
    '             ®ichard C. Siman
    '
    '=======================================================================================
    'Revision Trail
    '=======================================================================================
    '
    '   Company:
    '
    '   Module :  ACR120U API
    '
    '   Author :
    '
    '   Date   :
    '
    '   Revision Info :
    '
    '=======================================================================================





    '=============================== Error Code ===============================
    Public Const ERR_READER_NO_RESPONSE As Short = -5000
    Public Const ERR_ACR120_INTERNAL_UNEXPECTED As Short = -1000
    Public Const ERR_ACR120_PORT_INVALID As Short = -2000
    Public Const ERR_ACR120_PORT_OCCUPIED As Short = -2010
    Public Const ERR_ACR120_HANDLE_INVALID As Short = -2020
    Public Const ERR_ACR120_INCORRECT_PARAM As Short = -2030
    Public Const ERR_ACR120_READER_NO_TAG As Short = -3000
    Public Const ERR_ACR120_READER_READ_FAIL_AFTER_OP As Short = -3010
    Public Const ERR_ACR120_READER_NO_VALUE_BLOCK As Short = -3020
    Public Const ERR_ACR120_READER_OP_FAILURE As Short = -3030
    Public Const ERR_ACR120_READER_UNKNOWN As Short = -3040
    Public Const ERR_ACR120_READER_LOGIN_INVALID_STORED_KEY_FORMAT As Short = -4010
    Public Const ERR_ACR120_READER_WRITE_READ_AFTER_WRITE_ERROR As Short = -4020
    Public Const ERR_ACR120_READER_DEC_FAILURE_EMPTY As Short = -4030
    Public Const ERR_READER_VALUE_INC_OVERFLOW As Short = -4031
    Public Const ERR_READER_VALUE_OP_FAILURE As Short = -4032
    Public Const ERR_READER_VALUE_INVALID_BLOCK As Short = -4033
    Public Const ERR_READER_VALUE_ACCESS_FAILURE As Short = -4034





    '======================= Reader Ports for ACR120_Open ==========================
    Enum PORTS
        ACR120_USB1 = 0
        ACR120_USB2 = 1
        ACR120_USB3 = 2
        ACR120_USB4 = 3
        ACR120_USB5 = 4
        ACR120_USB6 = 5
        ACR120_USB7 = 6
        ACR120_USB8 = 7
    End Enum

    '======================== Key Type for ACR120_Login ===========================

    Enum KEYTYPES
        ACR120_LOGIN_KEYTYPE_A = &HAAS
        ACR120_LOGIN_KEYTYPE_B = &HBBS
        ACR120_LOGIN_KEYTYPE_DEFAULT_A = &HADS
        ACR120_LOGIN_KEYTYPE_DEFAULT_B = &HBDS
        ACR120_LOGIN_KEYTYPE_DEFAULT_F = &HFDS
        ACR120_LOGIN_KEYTYPE_STORED_A = &HAFS
        ACR120_LOGIN_KEYTYPE_STORED_B = &HBFS
    End Enum




    Structure tReaderStatus
        '// 0x01 = Type A; 0x02 = Type B; 0x03 = Type A + Type B
        Dim MifareInterfaceType As Byte
        '// Bit 0 = Mifare Light; Bit 1 = Mifare1K; Bit 2 = Mifare 4K; Bit 3 = Mifare DESFire
        '// Bit 4 = Mifare UltraLight; Bit 5 = JCOP30; Bit 6 = Shanghai Transport
        '// Bit 7 = MPCOS Combi; Bit 8 = ISO type B, Calypso
        '// Bit 9 - Bit 31 = To be defined
        <VBFixedArray(3)> Dim CardsSupported() As Byte
        Dim CardOpMode As Byte '// 0x00 = Type A; 0x01 = Type B TAG is being processed
        '// 0xFF = No TAG is being processed.
        Dim FWI As Byte '// the current FWI value (time out value)
        Dim RFU As Byte ' // To be defined
        Dim RFU2 As Short '// to be defined

        'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1026"'
        Public Sub Initialize()
            ReDim CardsSupported(3)
        End Sub
    End Structure








    '------------------------------------------------------------------------------------------
    'Prototype section
    '------------------------------------------------------------------------------------------
    '======================================================================================
    ' READER COMMANDS
    '======================================================================================



    'UPGRADE_WARNING: Structure PORTS may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1050"'
    Declare Function ACR120_Open Lib "ACR120U.DLL" (ByVal ReaderPort As PORTS) As Short

    Declare Function ACR120_Close Lib "ACR120U.DLL" (ByVal hReader As Short) As Short

    Declare Function ACR120_Reset Lib "ACR120U.DLL" (ByVal hReader As Short) As Short

    'UPGRADE_WARNING: Structure tReaderStatus may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1050"'
    Declare Function ACR120_Status Lib "ACR120U.DLL" (ByVal hReader As Short, ByRef pFirmwareVersion As Byte, ByRef pReaderStatus As tReaderStatus) As Short


    Declare Function ACR120_ReadRC531Reg Lib "ACR120U.DLL" Alias "ACR120_ReadRC500Reg" (ByVal hReader As Short, ByVal RegNo As Byte, ByRef pRegData As Byte) As Short


    Declare Function ACR120_WriteRC531Reg Lib "ACR120U.DLL" Alias "ACR120_WriteRC500Reg" (ByVal hReader As Short, ByVal RegNo As Byte, ByVal RegData As Byte) As Short


    Declare Function ACR120_DirectSend Lib "ACR120U.DLL" (ByVal hReader As Short, ByVal DataLength As Byte, ByRef pData As Byte, ByRef pResponseDataLength As Byte, ByRef pResponseData As Byte, ByVal TimedOut As Short) As Short


    Declare Function ACR120_DirectReceive Lib "ACR120U.DLL" (ByVal hReader As Short, ByVal RespectedDataLength As Byte, ByRef pReceivedDataLength As Byte, ByRef pReceivedData As Byte, ByVal TimedOut As Short) As Short




    Declare Function ACR120_RequestDLLVersion Lib "ACR120U.DLL" (ByRef pVersionInfoLen As Byte, ByRef pVersionInfo As Byte) As Short




    Declare Function ACR120_ReadEEPROM Lib "ACR120U.DLL" (ByVal hReader As Short, ByVal RegNo As Byte, ByRef pEEPROMData As Byte) As Short





    Declare Function ACR120_WriteEEPROM Lib "ACR120U.DLL" (ByVal hReader As Short, ByVal RegNo As Byte, ByVal eePROMData As Byte) As Short




    Declare Function ACR120_ReadUserPort Lib "ACR120U.DLL" (ByVal hReader As Short, ByRef pUserPortState As Byte) As Short




    Declare Function ACR120_WriteUserPort Lib "ACR120U.DLL" (ByVal hReader As Short, ByVal userPortState As Byte) As Short







    '======================================================================================
    ' CARD COMMANDS
    '======================================================================================


    Declare Function ACR120_Select Lib "ACR120U.DLL" (ByVal hReader As Short, ByRef pResultTagType As Byte, ByRef pResultTagLength As Byte, ByRef pResultSN As Byte) As Short



    'UPGRADE_WARNING: Structure KEYTYPES may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1050"'
    Declare Function ACR120_Login Lib "ACR120U.DLL" (ByVal hReader As Short, ByVal sector As Byte, ByVal keyType As KEYTYPES, ByVal storedNo As Byte, ByRef pKey As Byte) As Short


    Declare Function ACR120_Read Lib "ACR120U.DLL" (ByVal hReader As Short, ByVal block As Byte, ByRef pBlockData As Byte) As Short


    Declare Function ACR120_ReadValue Lib "ACR120U.DLL" (ByVal hReader As Short, ByVal block As Byte, ByRef pValueData As Integer) As Short


    Declare Function ACR120_Write Lib "ACR120U.DLL" (ByVal hReader As Short, ByVal block As Byte, ByRef pBlockData As Byte) As Short


    Declare Function ACR120_WriteValue Lib "ACR120U.DLL" (ByVal hReader As Short, ByVal block As Byte, ByVal valueData As Integer) As Short


    Declare Function ACR120_WriteMasterKey Lib "ACR120U.DLL" (ByVal hReader As Short, ByVal keyNo As Byte, ByRef pKey As Byte) As Short


    Declare Function ACR120_Inc Lib "ACR120U.DLL" (ByVal hReader As Short, ByVal block As Byte, ByVal value As Integer, ByRef pNewValue As Integer) As Short



    Declare Function ACR120_Dec Lib "ACR120U.DLL" (ByVal hReader As Short, ByVal block As Byte, ByVal value As Integer, ByRef pNewValue As Integer) As Short

    Declare Function ACR120_Copy Lib "ACR120U.DLL" (ByVal hReader As Short, ByVal srcBlock As Byte, ByVal desBlock As Byte, ByRef pNewValue As Integer) As Short



    Declare Function ACR120_Power Lib "ACR120U.DLL" (ByVal hReader As Short, ByVal State As Byte) As Short



    Declare Function ACR120_ListTags Lib "ACR120U.DLL" (ByVal hReader As Short, ByRef pNumTagFound As Byte, ByRef pTagType As Byte, ByRef pTagLength As Byte, ByRef pSN As Byte) As Short




    Declare Function ACR120_MultiTagSelect Lib "ACR120U.DLL" (ByVal hReader As Short, ByVal TagLength As Byte, ByRef SN As Byte, ByRef pResultTagType As Byte, ByRef pResultTagLength As Byte, ByRef pResultSN As Byte) As Short




    Declare Function ACR120_TxDataTelegram Lib "ACR120U.DLL" (ByVal hReader As Short, ByVal SendDataLength As Byte, ByRef pSendData As Byte, ByRef pReceivedDataLength As Byte, ByRef pReceivedData As Byte) As Short

    'Declare Function ACR120_Status Lib "ACR120U.DLL" (ByVal hReader As Integer, _
    ''                                      ByRef pFirmwareVersion As Byte, _
    ''                                      ByRef pReaderStatus As tReaderStatus) As Integer
End Module