// ==========================================================
// File: Teamwork.Client.ErrorHandler.cs
// Created: 2018.11.03
// Created By: Tim cadenbach
//  
// Copyright (C) 2018 Teamwork.com
// License: Apache License 2.0
// ==========================================================

#region

using System;

#endregion

namespace Teamwork.Shared.Common.Exceptions
{
    public static class ErrorHandler
    {
        public static void ThrowGenericTeamworkError(Exception ex)
        {
            throw ex;
        }
    }
}