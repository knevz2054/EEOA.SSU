using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplicationForAdmission.Models.Entities
{
    public enum Sex : byte
    {
        Male = 0,
        Female = 1
    }
    public static class SexExtensions
    {
        public static string ToFriendlyName(this Sex name)
        {
            switch (name)
            {
                case Sex.Male:
                    return "Male";
                case Sex.Female:
                    return "Female";
                default:
                    throw new Exception("Value is invalid");
            }
        }
    }

    public enum CivilStatus : byte
    {
        Single = 0,
        Married = 1,
        Widowed_Widower = 2,
        Divorced = 3,
        Separated = 4,
        Annulled = 5,
        LivingIn = 6,
        Civil_Partnership = 7
    }
    public static class CivilStatusExtensions
    {
        public static string ToFriendlyName(this CivilStatus name)
        {
            switch (name)
            {
                case CivilStatus.Single:
                    return "Single";
                case CivilStatus.Married:
                    return "Married";
                case CivilStatus.Widowed_Widower:
                    return "Widowed / Widower";
                case CivilStatus.Divorced:
                    return "Divorced";
                case CivilStatus.Separated:
                    return "Separated";
                case CivilStatus.Annulled:
                    return "Annulled";
                case CivilStatus.LivingIn:
                    return "Living-In";
                case CivilStatus.Civil_Partnership:
                    return "Civil Partnership";
                default:
                    throw new Exception("Value is invalid");
            }
        }
    }

    public enum SchoolSector : byte
    {
        Government = 0,
        Private = 1
    }
    public static class SchoolSectorExtensions
    {
        public static string ToFriendlyName(this SchoolSector name)
        {
            switch (name)
            {
                case SchoolSector.Government:
                    return "Government";
                case SchoolSector.Private:
                    return "Private";
                default:
                    throw new Exception("Value is invalid");
            }
        }
    }

    public enum StudenStatus : byte
    {
        New = 0,
        Shifter = 1,
        Transferee = 2,
        Returnee = 3,
        SecondCourser = 4
    }
    public static class StudenStatusExtensions
    {
        public static string ToFriendlyName(this StudenStatus name)
        {
            switch (name)
            {
                case StudenStatus.New:
                    return "New";
                case StudenStatus.Shifter:
                    return "Shifter";
                case StudenStatus.Transferee:
                    return "Transferee";
                case StudenStatus.Returnee:
                    return "Returnee";
                case StudenStatus.SecondCourser:
                    return "Second Courser";

                default:
                    throw new Exception("Value is invalid");
            }
        }
    }

    public enum TracksAndStrands : byte
    {
        ABM  = 0,
        STEM = 1,
        HUMSS = 2,
        GAS = 3,
        ArtsandDesignTrack = 4,
        SportsTrack = 5,
        AFA = 6,
        HE = 7,
        IA = 8,
        ICT = 9
    }
    public static class TracksAndStrandsExtensions
    {
        public static string ToFriendlyName(this TracksAndStrands name)
        {
            switch (name)
            {
                case TracksAndStrands.ABM:
                    return "Academic Track (ABM)";
                case TracksAndStrands.STEM:
                    return "Academic Track (STEM)";
                case TracksAndStrands.HUMSS:
                    return "Academic Track (HUMSS)";
                case TracksAndStrands.GAS:
                    return "Academic Track (GAS)";
                case TracksAndStrands.ArtsandDesignTrack:
                    return "Arts and Design Track";
                case TracksAndStrands.SportsTrack:
                    return "Sports Track";
                case TracksAndStrands.AFA:
                    return "Technical Vocational Livelihood Track (AFA)";
                case TracksAndStrands.HE:
                    return "Technical Vocational Livelihood Track (HE)";
                case TracksAndStrands.IA:
                    return "Technical Vocational Livelihood Track (IA)";
                case TracksAndStrands.ICT:
                    return "Technical Vocational Livelihood Track (ICT)";

                default:
                    throw new Exception("Value is invalid");
            }
        }
    }
}
