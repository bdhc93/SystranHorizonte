/*
Usuario: SuperAdmin
Contraseña: horizonte2015
*/
USE [DBSystran]
GO
SET IDENTITY_INSERT [dbo].[UserProfile] ON 

GO
INSERT [dbo].[UserProfile] ([UserId], [Username]) VALUES (1, N'SuperAdmin')
GO
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
GO
SET IDENTITY_INSERT [dbo].[webpages_Roles] ON 

GO
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (2, N'Admin')
GO
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (1, N'SuperAdmin')
GO
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (3, N'Vendedor')
GO
SET IDENTITY_INSERT [dbo].[webpages_Roles] OFF
GO
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 1)
GO
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (1, CAST(0x0000A55D01712CFA AS DateTime), NULL, 1, NULL, 0, N'AAtLrXvUbmFgesNSK7kHmOetNLUtkmYVk2n979y81M6+kNOqz4ZBTmofbKFwVMEwBg==', CAST(0x0000A55D01712CFA AS DateTime), N'', NULL, NULL)
GO
