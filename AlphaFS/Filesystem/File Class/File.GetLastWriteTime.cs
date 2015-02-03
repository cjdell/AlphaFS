/*  Copyright (C) 2008-2015 Peter Palotas, Jeffrey Jangli, Alexandr Normuradov
 *  
 *  Permission is hereby granted, free of charge, to any person obtaining a copy 
 *  of this software and associated documentation files (the "Software"), to deal 
 *  in the Software without restriction, including without limitation the rights 
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
 *  copies of the Software, and to permit persons to whom the Software is 
 *  furnished to do so, subject to the following conditions:
 *  
 *  The above copyright notice and this permission notice shall be included in 
 *  all copies or substantial portions of the Software.
 *  
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
 *  THE SOFTWARE. 
 */

using System;
using System.Security;

namespace Alphaleonis.Win32.Filesystem
{
   public static partial class File
   {
      #region GetLastWriteTime

      /// <summary>Gets the date and time that the specified file was last written to.</summary>
      /// <param name="path">The file for which to obtain write date and time information.</param>
      /// <returns>
      ///   A <see cref="System.DateTime"/> structure set to the date and time that the specified file was last written to. This value is
      ///   expressed in local time.
      /// </returns>
      [SecurityCritical]
      public static DateTime GetLastWriteTime(string path)
      {
         return GetLastWriteTimeInternal(null, path, false, PathFormat.RelativePath).ToLocalTime();
      }

      /// <summary>[AlphaFS] Gets the date and time that the specified file was last written to.</summary>
      /// <param name="path">The file for which to obtain write date and time information.</param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      /// <returns>
      ///   A <see cref="System.DateTime"/> structure set to the date and time that the specified file was last written to. This value is
      ///   expressed in local time.
      /// </returns>
      [SecurityCritical]
      public static DateTime GetLastWriteTime(string path, PathFormat pathFormat)
      {
         return GetLastWriteTimeInternal(null, path, false, pathFormat).ToLocalTime();
      }


      #region Transactional

      /// <summary>[AlphaFS] Gets the date and time that the specified file was last written to.</summary>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">The file for which to obtain write date and time information.</param>
      /// <returns>
      ///   A <see cref="System.DateTime"/> structure set to the date and time that the specified file was last written to. This value is
      ///   expressed in local time.
      /// </returns>
      [SecurityCritical]
      public static DateTime GetLastWriteTime(KernelTransaction transaction, string path)
      {
         return GetLastWriteTimeInternal(transaction, path, false, PathFormat.RelativePath).ToLocalTime();
      }

      /// <summary>[AlphaFS] Gets the date and time that the specified file was last written to.</summary>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">The file for which to obtain write date and time information.</param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      /// <returns>
      ///   A <see cref="System.DateTime"/> structure set to the date and time that the specified file was last written to. This value is
      ///   expressed in local time.
      /// </returns>
      [SecurityCritical]
      public static DateTime GetLastWriteTime(KernelTransaction transaction, string path, PathFormat pathFormat)
      {
         return GetLastWriteTimeInternal(transaction, path, false, pathFormat).ToLocalTime();
      }


      #endregion // Transacted


      #endregion // GetLastWriteTime

      #region GetLastWriteTimeUtc

      /// <summary>Gets the date and time, in coordinated universal time (UTC) time, that the specified file was last written to.</summary>
      /// <param name="path">The file for which to obtain write date and time information.</param>
      /// <returns>
      ///   A <see cref="System.DateTime"/> structure set to the date and time that the specified file was last written to. This value is
      ///   expressed in UTC time.
      /// </returns>
      [SecurityCritical]
      public static DateTime GetLastWriteTimeUtc(string path)
      {
         return GetLastWriteTimeInternal(null, path, true, PathFormat.RelativePath);
      }

      /// <summary>
      ///   [AlphaFS] Gets the date and time, in coordinated universal time (UTC) time, that the specified file was last written to.
      /// </summary>
      /// <param name="path">The file for which to obtain write date and time information.</param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      /// <returns>
      ///   A <see cref="System.DateTime"/> structure set to the date and time that the specified file was last written to. This value is
      ///   expressed in UTC time.
      /// </returns>
      [SecurityCritical]
      public static DateTime GetLastWriteTimeUtc(string path, PathFormat pathFormat)
      {
         return GetLastWriteTimeInternal(null, path, true, pathFormat);
      }


      #region Transactional

      /// <summary>
      ///   [AlphaFS] Gets the date and time, in coordinated universal time (UTC) time, that the specified file was last written to.
      /// </summary>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">The file for which to obtain write date and time information.</param>
      /// <returns>
      ///   A <see cref="System.DateTime"/> structure set to the date and time that the specified file was last written to. This value is
      ///   expressed in UTC time.
      /// </returns>
      [SecurityCritical]
      public static DateTime GetLastWriteTimeUtc(KernelTransaction transaction, string path)
      {
         return GetLastWriteTimeInternal(transaction, path, true, PathFormat.RelativePath);
      }

      /// <summary>
      ///   [AlphaFS] Gets the date and time, in coordinated universal time (UTC) time, that the specified file was last written to.
      /// </summary>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">The file for which to obtain write date and time information.</param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      /// <returns>
      ///   A <see cref="System.DateTime"/> structure set to the date and time that the specified file was last written to. This value is
      ///   expressed in UTC time.
      /// </returns>
      [SecurityCritical]
      public static DateTime GetLastWriteTimeUtc(KernelTransaction transaction, string path, PathFormat pathFormat)
      {
         return GetLastWriteTimeInternal(transaction, path, true, pathFormat);
      }

      #endregion // Transacted


      #endregion // GetLastWriteTimeUtc

      #region Internal Methods

      /// <summary>
      ///   [AlphaFS] Gets the date and time, in coordinated universal time (UTC) or local time, that the specified file or directory was last
      ///   written to.
      /// </summary>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">The file or directory for which to obtain write date and time information.</param>
      /// <param name="getUtc">
      ///   <see langword="true"/> gets the Coordinated Universal Time (UTC), <see langword="false"/> gets the local time.
      /// </param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      /// <returns>
      ///   A <see cref="System.DateTime"/> structure set to the date and time that the specified file or directory was last written to.
      ///   Depending on <paramref name="getUtc"/> this value is expressed in UTC- or local time.
      /// </returns>
      [SecurityCritical]
      internal static DateTime GetLastWriteTimeInternal(KernelTransaction transaction, string path, bool getUtc, PathFormat pathFormat)
      {
         NativeMethods.FILETIME lastWriteTime = GetAttributesExInternal<NativeMethods.WIN32_FILE_ATTRIBUTE_DATA>(transaction, path, pathFormat).ftLastWriteTime;

         return getUtc
            ? DateTime.FromFileTimeUtc(lastWriteTime)
            : DateTime.FromFileTime(lastWriteTime);
      }

      #endregion // GetLastWriteTimeUtcInternal
   }
}
