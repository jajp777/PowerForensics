﻿using System;
using System.IO;
using System.Management.Automation;
using System.Text.RegularExpressions;
using InvokeIR.Win32;

namespace InvokeIR.PowerForensics.DD
{

    public class DD
    {
        public static void Get(string inFile, string outFile, long offset, int blockSize, int count)
        {

            IntPtr hVolume = NativeMethods.getHandle(inFile);
            FileStream streamToRead = NativeMethods.getFileStream(hVolume);
            
            long sizeToRead = blockSize * count;

            // Read sizeToRead bytes from the Volume
            byte[] buffer = NativeMethods.readDrive(streamToRead, offset, sizeToRead);

            // Open file for reading
            System.IO.FileStream _FileStream = new System.IO.FileStream(outFile, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            // Writes a block of bytes to this stream using data from a byte array.
            _FileStream.Write(buffer, 0, buffer.Length);
            // close file stream
            _FileStream.Close();
        }
    }

    #region ExportDDCommand
    /// <summary> 
    /// This class implements the Export-PowerDD cmdlet. 
    /// </summary> 

    [Cmdlet("Export", "DD", SupportsShouldProcess = true)]
    public class ExportDDCommand : PSCmdlet
    {
        #region Parameters

        /// <summary> 
        /// This parameter provides the Name of the File or Volume
        /// that should be read from (Ex. \\.\C: or C).
        /// </summary> 

        [Parameter(Mandatory = true)]
        public string InFile
        {
            get { return inFile; }
            set { inFile = value; }
        }
        private string inFile;

        /// <summary> 
        /// This parameter provides the Name of the File
        /// that the read bytes should be output to.
        /// </summary> 

        [Parameter(Mandatory = true)]
        public string OutFile
        {
            get { return outFile; }
            set { outFile = value; }
        }
        private string outFile;

        /// <summary> 
        /// This parameter provides the Offset into the 
        /// specified InFile to begin reading.
        /// </summary> 

        [Parameter(Mandatory = true)]
        public long Offset
        {
            get { return offset; }
            set { offset = value; }
        }
        private long offset;

        /// <summary> 
        /// This parameter provides the size of blocks to be
        /// read from the specified InFile.
        /// </summary> 

        [Parameter(Mandatory = true)]
        public int BlockSize
        {
            get { return blockSize; }
            set { blockSize = value; }
        }
        private int blockSize;

        /// <summary> 
        /// This parameter provides the Count of Blocks
        /// to read from the specified InFile.
        /// </summary> 

        [Parameter(Mandatory = true)]
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private int count;

        #endregion Parameters

        #region Cmdlet Overrides

        /// <summary> 
        /// The ProcessRecord instantiates a Reads bytes from the InFile
        /// and outputs to the OutFile.
        /// </summary> 

        protected override void ProcessRecord()
        {

            Regex lettersOnly = new Regex("^[a-zA-Z]{1}$");

            if (lettersOnly.IsMatch(inFile))
            {

                inFile = @"\\.\" + inFile + ":";

            }

            WriteDebug("VolumeName: " + inFile);

            DD.Get(inFile, outFile, offset, blockSize, count);

        } // ProcessRecord 

        #endregion Cmdlet Overrides

    } // End ExportPowerDDCommand class. 

    #endregion ExportDDCommand
  
}