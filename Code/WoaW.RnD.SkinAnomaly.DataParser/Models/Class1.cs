using System;
using System.Collections.Generic;

namespace WoaW.RnD.SkinAnomaly.DataParser.Models
{
    public class Id
    {
        public string oid { get; set; }
    }

    public class Diagnosis
    {
        public string Key { get; set; }
        public string term { get; set; }
    }

    public class Date
    {
        public string numberLong { get; set; }
    }

    public class Edited
    {
        public Date2 date { get; set; }
    }

    public class Indexed
    {
        public Date3 date { get; set; }
    }

    public class Lesion
    {
        public string category { get; set; }
        public string name { get; set; }
        public string degree { get; set; }
    }

    public class Localization
    {
        public string category { get; set; }
        public string name { get; set; }
    }

    public class Patho
    {
        public string category { get; set; }
        public string term { get; set; }
    }

    public class Date2
    {
        public string numberLong { get; set; }
        public static implicit operator Date2( DateTime t)
        {
            return new Date2() { numberLong = t.ToString() };
        }
    }

    public class Reviewed
    {
        public Date2 date { get; set; }
    }

    public class Date3
    {
        public string numberLong { get; set; }

        public static implicit operator Date3( DateTime t)
        {
            return new Date3() { numberLong = t.ToString() };
        }
    }

    public class Submitted
    {
        public Date3 date { get; set; }
    }

    public class Symptom
    {
        public string term { get; set; }
    }

    public class Taken
    {
        //public DateTime date { get; set; }
        public Date3 date { get; set; }
    }

    public class DiseasRecord
    {
        public Id _id { get; set; }
        public int MemberRating { get; set; }
        public string agegroup { get; set; }
        public int @case { get; set; }
        public string comment { get; set; }
        public string country { get; set; }
        public string cpsadboardcomments { get; set; }
        public string cpscasenotes { get; set; }
        public string cpscommenttoeditor { get; set; }
        public string cpsfirstname { get; set; }
        public string cpslastname { get; set; }
        public bool cpsprocessed { get; set; }
        public string cpsrejectionreasonid { get; set; }
        public string cpsusercity { get; set; }
        public string cpsuserstate { get; set; }
        public string darkskin { get; set; }
        public string description { get; set; }
        public List<Diagnosis> diagnosis { get; set; }
        public Edited edited { get; set; }
        public string filename { get; set; }
        public string followup { get; set; }
        public string followuptext { get; set; }
        public object histology { get; set; }
        public string immuno { get; set; }
        public Indexed indexed { get; set; }
        public string indexer { get; set; }
        public List<Lesion> lesion { get; set; }
        public List<Localization> localization { get; set; }
        public string name { get; set; }
        public List<Patho> patho { get; set; }
        public string patient { get; set; }
        public string pregnant { get; set; }
        public Reviewed reviewed { get; set; }
        public string reviewer { get; set; }
        public string searchterms { get; set; }
        public string status { get; set; }
        public Submitted submitted { get; set; }
        public string submitter { get; set; }
        public List<Symptom> symptom { get; set; }
        public Taken taken { get; set; }
        public string type { get; set; }
    }
}
