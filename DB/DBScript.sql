 
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/29/2020 1:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_CardTransaction]    Script Date: 12/29/2020 1:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CardTransaction](
	[Id] [bigint] NOT NULL,
	[HolderName] [nvarchar](100) NOT NULL,
	[BillingAddress] [nvarchar](200) NOT NULL,
	[CardNumber] [nvarchar](19) NOT NULL,
	[CCV] [nvarchar](4) NOT NULL,
	[ExpYear] [int] NOT NULL,
	[ExpMonth] [int] NOT NULL,
 CONSTRAINT [PK_tbl_CardTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Merchant]    Script Date: 12/29/2020 1:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Merchant](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Website] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[LastLoging] [datetime2](7) NULL,
	[InsertDate] [datetime2](7) NOT NULL,
	[ModifyDate] [datetime2](7) NULL,
	[TimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_tbl_Merchant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_MerchantProfile]    Script Date: 12/29/2020 1:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_MerchantProfile](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Website] [nvarchar](max) NULL,
	[Logo] [nvarchar](max) NULL,
	[Mode] [int] NOT NULL,
	[APIKey] [nvarchar](max) NULL,
	[MerchantId] [bigint] NOT NULL,
	[InsertDate] [datetime2](7) NOT NULL,
	[ModifyDate] [datetime2](7) NULL,
	[TimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_tbl_MerchantProfile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_MerchantProfilesPaymentMethods]    Script Date: 12/29/2020 1:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_MerchantProfilesPaymentMethods](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PaymentMethodId] [bigint] NULL,
	[MerchantProfileId] [bigint] NULL,
	[InsertDate] [datetime2](7) NOT NULL,
	[ModifyDate] [datetime2](7) NULL,
	[TimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_tbl_MerchantProfilesPaymentMethods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_PaymentMethod]    Script Date: 12/29/2020 1:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PaymentMethod](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Logo] [nvarchar](max) NULL,
	[InsertDate] [datetime2](7) NOT NULL,
	[ModifyDate] [datetime2](7) NULL,
	[TimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_tbl_PaymentMethod] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TemporaryTransaction]    Script Date: 12/29/2020 1:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TemporaryTransaction](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Amount_Currency] [nvarchar](max) NULL,
	[Amount_Value] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[RedirectUrl] [nvarchar](max) NULL,
	[WebhookUrl] [nvarchar](max) NULL,
	[Locale] [nvarchar](max) NULL,
	[Metadata] [nvarchar](max) NULL,
	[SequenceType] [int] NULL,
	[CustomerId] [nvarchar](max) NULL,
	[MandateId] [nvarchar](max) NULL,
	[MerchantProfileId] [bigint] NULL,
	[TestMode] [bit] NULL,
	[TransctionCode] [nvarchar](50) NOT NULL,
	[PaymentStatus] [nvarchar](max) NULL,
	[InsertDate] [datetime2](7) NOT NULL,
	[ModifyDate] [datetime2](7) NULL,
	[TimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_tbl_TemporaryTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TransactionBase]    Script Date: 12/29/2020 1:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TransactionBase](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TransctionCode] [nvarchar](50) NOT NULL,
	[TransactionDate] [datetime2](7) NOT NULL,
	[MerchantProfileId] [bigint] NULL,
	[Amount_Currency] [nvarchar](max) NULL,
	[Amount_Value] [nvarchar](max) NULL,
	[TemporaryTransactionId] [bigint] NULL,
	[InsertDate] [datetime2](7) NOT NULL,
	[ModifyDate] [datetime2](7) NULL,
	[TimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_tbl_TransactionBase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201229121920_Checkout_InitDB', N'5.0.1')
GO
SET IDENTITY_INSERT [dbo].[tbl_Merchant] ON 
GO
INSERT [dbo].[tbl_Merchant] ([Id], [Name], [Website], [Email], [Phone], [Password], [LastLoging], [InsertDate], [ModifyDate]) VALUES (1, N'Mahdavy.com', N'http://www.mahdavy.com', N'abolfazl.mahdavi@gmail.com', N'969696', N'123', NULL, CAST(N'2020-12-29T13:19:18.9851753' AS DateTime2), NULL)
GO
SET IDENTITY_INSERT [dbo].[tbl_Merchant] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_MerchantProfile] ON 
GO
INSERT [dbo].[tbl_MerchantProfile] ([Id], [Name], [Website], [Logo], [Mode], [APIKey], [MerchantId], [InsertDate], [ModifyDate]) VALUES (1, N'Mahdavi Shop 1', N'shop.mahdavy.com', N'https://acropaq.com/image/data/logo.png', 1, N'test_a02f7e6a-7768-4244-8032-8979f25d9581', 1, CAST(N'2020-12-29T13:19:18.9927784' AS DateTime2), NULL)
GO
INSERT [dbo].[tbl_MerchantProfile] ([Id], [Name], [Website], [Logo], [Mode], [APIKey], [MerchantId], [InsertDate], [ModifyDate]) VALUES (2, N'Mahdavi Shop', N'shop.mahdavy.com', N'https://acropaq.com/image/data/logo.png', 0, N'live_974281d1-0e8d-4279-a4fa-4e37cd002b74', 1, CAST(N'2020-12-29T13:19:18.9931918' AS DateTime2), NULL)
GO
SET IDENTITY_INSERT [dbo].[tbl_MerchantProfile] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_MerchantProfilesPaymentMethods] ON 
GO
INSERT [dbo].[tbl_MerchantProfilesPaymentMethods] ([Id], [PaymentMethodId], [MerchantProfileId], [InsertDate], [ModifyDate]) VALUES (1, 1, 1, CAST(N'2020-12-29T13:19:18.9932388' AS DateTime2), NULL)
GO
INSERT [dbo].[tbl_MerchantProfilesPaymentMethods] ([Id], [PaymentMethodId], [MerchantProfileId], [InsertDate], [ModifyDate]) VALUES (2, 2, 1, CAST(N'2020-12-29T13:19:18.9933665' AS DateTime2), NULL)
GO
INSERT [dbo].[tbl_MerchantProfilesPaymentMethods] ([Id], [PaymentMethodId], [MerchantProfileId], [InsertDate], [ModifyDate]) VALUES (3, 4, 1, CAST(N'2020-12-29T13:19:18.9933728' AS DateTime2), NULL)
GO
SET IDENTITY_INSERT [dbo].[tbl_MerchantProfilesPaymentMethods] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_PaymentMethod] ON 
GO
INSERT [dbo].[tbl_PaymentMethod] ([Id], [Name], [Logo], [InsertDate], [ModifyDate]) VALUES (1, N'ApplePay', N'fab fa-apple-pay fa-lg', CAST(N'2020-12-29T13:19:18.9919453' AS DateTime2), NULL)
GO
INSERT [dbo].[tbl_PaymentMethod] ([Id], [Name], [Logo], [InsertDate], [ModifyDate]) VALUES (2, N'CreditCard', N'fa fa-credit-card fa-lg', CAST(N'2020-12-29T13:19:18.9921412' AS DateTime2), NULL)
GO
INSERT [dbo].[tbl_PaymentMethod] ([Id], [Name], [Logo], [InsertDate], [ModifyDate]) VALUES (3, N'DirectDebit', N'fa fa-credit-card fa-lg', CAST(N'2020-12-29T13:19:18.9921481' AS DateTime2), NULL)
GO
INSERT [dbo].[tbl_PaymentMethod] ([Id], [Name], [Logo], [InsertDate], [ModifyDate]) VALUES (4, N'BankTransfer', N'fa fa-university fa-lg', CAST(N'2020-12-29T13:19:18.9921489' AS DateTime2), NULL)
GO
SET IDENTITY_INSERT [dbo].[tbl_PaymentMethod] OFF
GO
/****** Object:  Index [IX_tbl_MerchantProfile_MerchantId]    Script Date: 12/29/2020 1:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_MerchantProfile_MerchantId] ON [dbo].[tbl_MerchantProfile]
(
	[MerchantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_MerchantProfilesPaymentMethods_MerchantProfileId]    Script Date: 12/29/2020 1:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_MerchantProfilesPaymentMethods_MerchantProfileId] ON [dbo].[tbl_MerchantProfilesPaymentMethods]
(
	[MerchantProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_MerchantProfilesPaymentMethods_PaymentMethodId]    Script Date: 12/29/2020 1:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_MerchantProfilesPaymentMethods_PaymentMethodId] ON [dbo].[tbl_MerchantProfilesPaymentMethods]
(
	[PaymentMethodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_TemporaryTransaction_MerchantProfileId]    Script Date: 12/29/2020 1:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_TemporaryTransaction_MerchantProfileId] ON [dbo].[tbl_TemporaryTransaction]
(
	[MerchantProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_TransactionBase_MerchantProfileId]    Script Date: 12/29/2020 1:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_TransactionBase_MerchantProfileId] ON [dbo].[tbl_TransactionBase]
(
	[MerchantProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbl_TransactionBase_TemporaryTransactionId]    Script Date: 12/29/2020 1:25:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_tbl_TransactionBase_TemporaryTransactionId] ON [dbo].[tbl_TransactionBase]
(
	[TemporaryTransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_CardTransaction]  WITH CHECK ADD  CONSTRAINT [FK_tbl_CardTransaction_tbl_TransactionBase_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[tbl_TransactionBase] ([Id])
GO
ALTER TABLE [dbo].[tbl_CardTransaction] CHECK CONSTRAINT [FK_tbl_CardTransaction_tbl_TransactionBase_Id]
GO
ALTER TABLE [dbo].[tbl_MerchantProfile]  WITH CHECK ADD  CONSTRAINT [FK_tbl_MerchantProfile_tbl_Merchant_MerchantId] FOREIGN KEY([MerchantId])
REFERENCES [dbo].[tbl_Merchant] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_MerchantProfile] CHECK CONSTRAINT [FK_tbl_MerchantProfile_tbl_Merchant_MerchantId]
GO
ALTER TABLE [dbo].[tbl_MerchantProfilesPaymentMethods]  WITH CHECK ADD  CONSTRAINT [FK_tbl_MerchantProfilesPaymentMethods_tbl_MerchantProfile_MerchantProfileId] FOREIGN KEY([MerchantProfileId])
REFERENCES [dbo].[tbl_MerchantProfile] ([Id])
GO
ALTER TABLE [dbo].[tbl_MerchantProfilesPaymentMethods] CHECK CONSTRAINT [FK_tbl_MerchantProfilesPaymentMethods_tbl_MerchantProfile_MerchantProfileId]
GO
ALTER TABLE [dbo].[tbl_MerchantProfilesPaymentMethods]  WITH CHECK ADD  CONSTRAINT [FK_tbl_MerchantProfilesPaymentMethods_tbl_PaymentMethod_PaymentMethodId] FOREIGN KEY([PaymentMethodId])
REFERENCES [dbo].[tbl_PaymentMethod] ([Id])
GO
ALTER TABLE [dbo].[tbl_MerchantProfilesPaymentMethods] CHECK CONSTRAINT [FK_tbl_MerchantProfilesPaymentMethods_tbl_PaymentMethod_PaymentMethodId]
GO
ALTER TABLE [dbo].[tbl_TemporaryTransaction]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TemporaryTransaction_tbl_MerchantProfile_MerchantProfileId] FOREIGN KEY([MerchantProfileId])
REFERENCES [dbo].[tbl_MerchantProfile] ([Id])
GO
ALTER TABLE [dbo].[tbl_TemporaryTransaction] CHECK CONSTRAINT [FK_tbl_TemporaryTransaction_tbl_MerchantProfile_MerchantProfileId]
GO
ALTER TABLE [dbo].[tbl_TransactionBase]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TransactionBase_tbl_MerchantProfile_MerchantProfileId] FOREIGN KEY([MerchantProfileId])
REFERENCES [dbo].[tbl_MerchantProfile] ([Id])
GO
ALTER TABLE [dbo].[tbl_TransactionBase] CHECK CONSTRAINT [FK_tbl_TransactionBase_tbl_MerchantProfile_MerchantProfileId]
GO
ALTER TABLE [dbo].[tbl_TransactionBase]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TransactionBase_tbl_TemporaryTransaction_TemporaryTransactionId] FOREIGN KEY([TemporaryTransactionId])
REFERENCES [dbo].[tbl_TemporaryTransaction] ([Id])
GO
ALTER TABLE [dbo].[tbl_TransactionBase] CHECK CONSTRAINT [FK_tbl_TransactionBase_tbl_TemporaryTransaction_TemporaryTransactionId]
GO
