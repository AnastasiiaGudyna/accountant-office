USE [master]
GO

IF DB_ID('AccountantDb') IS NOT NULL
  set noexec on

CREATE DATABASE [AccountantDb];
GO