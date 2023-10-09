using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using RestSharp;
using RestSharp.Serializers.Xml;
using RestSharp.Serializers.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using RestSharp.Serializers.NewtonsoftJson;

namespace GeniusApp
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [Serializable()]
    public class LyricsData
    {
       
        public Lyrics lyrics { get; set; }
        
    }

    public class Lyrics
    {   public string _type { get; set; }
        public string api_path { get; set; }
        public LyricsContent lyrics { get; set; }
        public string path { get; set; }
        public int song_id { get; set; }
        public TrackingData tracking_data { get; set; }
       
    }

    public class LyricsContent
    {
        public Body_Song body { get; set; }
    }

    public class Body_Song
    {
        public string plain { get; set; }
    }

    public class TrackingData
    {
        public int song_id { get; set; }
        public string title { get; set; }
        public string primary_artist { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int primary_artist_id { get; set; }
        public string primary_album { get; set; }
        public int primary_album_id { get; set; }
        public string tag { get; set; }
        public string primary_tag { get; set; }
        public int primary_tag_id { get; set; }
        public bool music { get; set; }
        public string annotatable_type { get; set; }
        public int annotatable_id { get; set; }
        public bool featured_video { get; set; }
        public List<int> cohort_ids { get; set; }
        public bool has_verified_callout { get; set; }
        public bool has_featured_annotation { get; set; }
        public string created_at { get; set; }
        public string created_month { get; set; }
        public string created_year { get; set; }
        public string song_tier { get; set; }
        public bool has_recirculated_articles { get; set; }
        public string lyrics_language { get; set; }
        public bool has_apple_match { get; set; }
        public string release_date { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int nrm_tier { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string nrm_target_date { get; set; }
        public bool has_description { get; set; }
        public bool has_youtube_url { get; set; }
        public bool has_translation_qa { get; set; }
        public int comment_count { get; set; }
        public bool hot { get; set; }
        public bool has_recommendations { get; set; }
        public bool has_stubhub_artist { get; set; }
        public bool has_stubhub_link { get; set; }
        public bool translation { get; set; }
        public string recommendation_strategy { get; set; }
        public string web_interstitial_variant { get; set; }
        public string platform_variant { get; set; }
    }



    public class GetSongInfo : System.Web.Services.WebService
    {

        [WebMethod]
        public string[] getSongInfo(String id)
        {
             //Create client using API string for song lyrics
             var client = new RestClient("https://genius-song-lyrics1.p.rapidapi.com/song/lyrics/?id="+id+"&text_format=plain",
                 configureSerialization: s => s.UseNewtonsoftJson());
             //Create Request using API and Host strings
             var request = new RestRequest();
             request.AddHeader("X-RapidAPI-Key", "461a1928d0msh82e608a6e604d2fp10ec86jsnd3930b90e2ba");
             request.AddHeader("X-RapidAPI-Host", "genius-song-lyrics1.p.rapidapi.com");
            //Collect Results 
            RestResponse response = client.Execute(request);
            
            String[] result = new string[6];
            try
            {
                //Decode JSON object
                LyricsData data = JsonConvert.DeserializeObject<LyricsData>(response.Content);
                //Pack desired info into array
                result[0] = "Title: " + data.lyrics.tracking_data.title;
                result[1] = "";
                result[2] = "Artist: " + data.lyrics.tracking_data.primary_artist;
                result[3] = "Relase Date: " + data.lyrics.tracking_data.release_date;
                result[4] = "Tag: " + data.lyrics.tracking_data.tag;
                result[5] = "Lyrics: " + data.lyrics.lyrics.body.plain;
            }
            catch(Exception e)
            {   
                //Catch any exceptions 
                result[0] = "An error was encountered";
                Console.WriteLine(e.Message);
            }
            //return results
            return result;
        }

        
    }
}
