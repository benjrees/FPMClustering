Imports System.Xml
Imports System.io

Public Enum NeighbourhoodFunction
    Bubble
    Gaussian
End Enum

Public Class ClusterConfig

    Private mSourceFile As String
    Private mOutputPath As String
    Private mSQLString As String
    Private mFileChanged As Boolean
    Private Const INITSQL As String = "SELECT * FROM [" & ClusterApp.TABLENAME & "]"
    Private Const INITWIDTH As Integer = 3
    Private Const INITITERATIONS As Integer = 100
    Private Const INITETA As Single = 0.9
    Private Const INITSIGMA As Single = 1.9
    Private Const INITETAEND As Single = 0.1
    Private Const INITSIGMAEND As Single = 0.5


    Private mNames As System.Collections.Specialized.StringCollection
    Private mIterations As Integer
    Private mWidth As Integer
    Private mEta As Single
    Private mEtaEnd As Single
    Private mSigma As Single
    Private mSigmaEnd As Single
    Private mNormalise As Boolean
    Private mRandomise As Boolean
    Private mNeighbourhood As NeighbourhoodFunction
    Private mWeightsCol As String



    Public Property Normalise() As Boolean
        Get
            Return mNormalise
        End Get
        Set(ByVal value As Boolean)
            mNormalise = value
            FileChanged = True
        End Set
    End Property



    Public Property Randomise() As Boolean
        Get
            Return mRandomise
        End Get
        Set(ByVal value As Boolean)
            mRandomise = value
            FileChanged = True
        End Set
    End Property


    Public Property Eta() As Single
        Get
            Return mEta
        End Get
        Set(ByVal value As Single)
            mEta = value
            FileChanged = True
        End Set
    End Property

    Public Property Sigma() As Single
        Get
            Return mSigma
        End Get
        Set(ByVal value As Single)
            mSigma = value
            FileChanged = True
        End Set
    End Property

    Public Property Neighbourhood() As NeighbourhoodFunction
        Get
            Return mNeighbourhood
        End Get
        Set(ByVal value As NeighbourhoodFunction)
            mNeighbourhood = value
        End Set
    End Property

    Public Property EtaEnd() As Single
        Get
            Return mEtaEnd
        End Get
        Set(ByVal value As Single)
            mEtaEnd = value
            FileChanged = True
        End Set
    End Property

    Public Property SigmaEnd() As Single
        Get
            Return mSigmaEnd
        End Get
        Set(ByVal value As Single)
            mSigmaEnd = value
            FileChanged = True
        End Set
    End Property


    Public Property Iterations() As Integer
        Get
            Return mIterations
        End Get
        Set(ByVal value As Integer)
            mIterations = value
            FileChanged = True
        End Set
    End Property

    Public Property Width() As Integer
        Get
            Return mWidth
        End Get
        Set(ByVal value As Integer)
            mWidth = value
            FileChanged = True
        End Set
    End Property


    Public Property Names() As System.Collections.Specialized.StringCollection
        Get
            Return mNames
        End Get
        Set(ByVal value As System.Collections.Specialized.StringCollection)
            mNames = value
            FileChanged = True
        End Set
    End Property

    Public Property WeightsCol() As String
        Get
            Return mWeightsCol
        End Get
        Set(ByVal value As String)
            mWeightsCol = value
        End Set
    End Property

    Public Property FileChanged() As Boolean
        Get
            Return mFileChanged
        End Get
        Set(ByVal value As Boolean)
            mFileChanged = value
        End Set
    End Property

    Public Property OutputPath() As String
        Get
            Return mOutputPath
        End Get
        Set(ByVal value As String)
            mOutputPath = value
            FileChanged = True
        End Set
    End Property


    Public Property SourceFile() As String
        Get
            Return mSourceFile
        End Get
        Set(ByVal value As String)
            mSourceFile = value
            FileChanged = True
        End Set
    End Property

    Public Property SQLString() As String
        Get
            Return mSQLString
        End Get
        Set(ByVal value As String)
            mSQLString = value
            FileChanged = True
        End Set
    End Property

    Public ReadOnly Property TORSigma() As Double
        Get

            Return Iterations * SigmaEnd / (Sigma - SigmaEnd)

        End Get
    End Property



    Public ReadOnly Property TOREta() As Double
        Get

            Return Iterations * EtaEnd / (Eta - EtaEnd)

        End Get
    End Property

    Public Sub New()

        SQLString = INITSQL

        Names = New System.Collections.Specialized.StringCollection()
        Width = INITWIDTH
        Iterations = INITITERATIONS
        Eta = INITETA
        Sigma = INITSIGMA
        EtaEnd = INITETAEND
        SigmaEnd = INITSIGMAEND
        Normalise = False
        Randomise = True

    End Sub


    Public Shared Sub serialise(ByVal obj As ClusterConfig, ByVal filename As String)

        Dim s As New Serialization.XmlSerializer(GetType(ClusterConfig))

        Dim writer As New StreamWriter(filename)

        s.Serialize(writer, obj)

        writer.Close()


    End Sub


    Public Shared Function deserialise(ByVal filename As String)

        Dim newCC As ClusterConfig

        Dim s As New Serialization.XmlSerializer(GetType(ClusterConfig))

        Dim reader As New StreamReader(filename)

        newCC = CType(s.Deserialize(reader), ClusterConfig)

        reader.Close()
        Return newCC


    End Function


End Class
