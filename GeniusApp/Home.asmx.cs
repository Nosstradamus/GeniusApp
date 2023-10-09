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
using System.Windows.Forms;
namespace GeniusApp
{
    /// <summary>
    /// Summary description for Home:
    /// Takes inout from HTML text box and searches Genius API
    /// using their multi search function. Recieves and decodes
    /// corresponding JSON object looking at the top hit from the search.
    /// Redirects the ID string to the other classes based on the defined
    /// types. Recieves results from other classes and returns to HTML for output.
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

   
    public class Home : System.Web.Services.WebService
    {

        [WebMethod]
        public String Search(String input)
        {   //Creates client using multi search API call
            var client = new RestClient("https://genius-song-lyrics1.p.rapidapi.com/search/multi/?q="+input+"&per_page=3&page=1");
            //Creates request with host and key
            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", "85e567e6c5msh78b9419bc244368p122c01jsn1738bee94e5a");
            request.AddHeader("X-RapidAPI-Host", "genius-song-lyrics1.p.rapidapi.com");
            //Gathers JSON response
            RestResponse response = client.Execute(request);

            //string for output
            string result;
            //Decodes JSON using class definitions below
            SearchRootObject searchResult = JsonConvert.DeserializeObject<SearchRootObject>(response.Content);
            //Strings to call appropriate decode class.
            String type = searchResult.Sections[0].Hits[0].Type;
            String id = searchResult.Sections[0].Hits[0].Result.Id.ToString();
            //Create class objects
            GetArtistInfo artist = new GetArtistInfo();
            GetAlbumInfo album = new GetAlbumInfo();
            GetSongInfo song = new GetSongInfo();
            //create output arrays
            String[] albumResult;
            String[] artistResult;
            String[] songResult;
            //Call class based on type from API. set to lowercase for consistency
            //All output strings are created using ~ as delimiters for String.Split in javascript
            switch (type.ToLower())
            {
                case "artist":
                    artistResult = artist.getArtistInfo(id);
                    result = artistResult[0] + "~" + artistResult[1] + "~" + artistResult[2] + "~" + artistResult[3]+ "~~";
                    break;
                case "song":
                    songResult = song.getSongInfo(id);
                    result = songResult[0] + "~" + songResult[1] + "~" + songResult[2] + "~" + songResult[3]+ "~" + songResult[4] + "~" + songResult[5];
                    break;
                case "album":
                    albumResult = album.getAlbumInfo(id);
                    result = albumResult[0]+"~"+ albumResult[1] + "~" + albumResult[2] + "~" + albumResult[3]+ "~~";
                    break;
                default:
                    //If none of above types were found, its output we arent concerned with
                    result = "Your search did not yield any results.~~~~~";
                    break;


            }
            
            return result;

        }

   
    }
    //classes to decode Json object
    public class SongResult
    {
        [JsonProperty("_type")]
        public string Type { get; set; }

        [JsonProperty("annotation_count", NullValueHandling = NullValueHandling.Ignore)]
        public int AnnotationCount { get; set; }

        [JsonProperty("api_path")]
        public string ApiPath { get; set; }

        [JsonProperty("artist_names")]
        public string ArtistNames { get; set; }

        [JsonProperty("full_title")]
        public string FullTitle { get; set; }

        [JsonProperty("header_image_thumbnail_url")]
        public string HeaderImageThumbnailUrl { get; set; }

        [JsonProperty("header_image_url")]
        public string HeaderImageUrl { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("instrumental")]
        public bool Instrumental { get; set; }

        [JsonProperty("lyrics_owner_id")]
        public int LyricsOwnerId { get; set; }

        [JsonProperty("lyrics_state")]
        public string LyricsState { get; set; }

        [JsonProperty("lyrics_updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public long LyricsUpdatedAt { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("pyongs_count", NullValueHandling = NullValueHandling.Ignore)]
        public int PyongsCount { get; set; }

        [JsonProperty("relationships_index_url")]
        public string RelationshipsIndexUrl { get; set; }

        [JsonProperty("release_date_components")]
        public Search_ReleaseDateComponents ReleaseDateComponents { get; set; }

        [JsonProperty("release_date_for_display")]
        public string ReleaseDateForDisplay { get; set; }

        [JsonProperty("release_date_with_abbreviated_month_for_display")]
        public string ReleaseDateWithAbbreviatedMonthForDisplay { get; set; }

        [JsonProperty("song_art_image_thumbnail_url")]
        public string SongArtImageThumbnailUrl { get; set; }

        [JsonProperty("song_art_image_url")]
        public string SongArtImageUrl { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("title_with_featured")]
        public string TitleWithFeatured { get; set; }

        [JsonProperty("updated_by_human_at")]
        public long UpdatedByHumanAt { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("featured_artists")]
        public List<object> FeaturedArtists { get; set; }

        [JsonProperty("primary_artist")]
        public PrimaryArtist PrimaryArtist { get; set; }
    }

    public class Search_ReleaseDateComponents
    {

        [JsonProperty("year", NullValueHandling = NullValueHandling.Ignore)]
        public int Year { get; set; }

        [JsonProperty("month", NullValueHandling = NullValueHandling.Ignore)]
        public int Month { get; set; }

        [JsonProperty("day", NullValueHandling = NullValueHandling.Ignore)]
        public int Day { get; set; }
    }

    public class Stats
    {
        [JsonProperty("unreviewed_annotations")]
        public int UnreviewedAnnotations { get; set; }

        [JsonProperty("hot")]
        public bool Hot { get; set; }

        [JsonProperty("pageviews")]
        public int Pageviews { get; set; }
    }

    public class PrimaryArtist
    {
        [JsonProperty("_type")]
        public string Type { get; set; }

        [JsonProperty("api_path")]
        public string ApiPath { get; set; }

        [JsonProperty("header_image_url")]
        public string HeaderImageUrl { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("index_character")]
        public string IndexCharacter { get; set; }

        [JsonProperty("is_meme_verified")]
        public bool IsMemeVerified { get; set; }

        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class TopHit
    {
        [JsonProperty("highlights")]
        public List<object> Highlights { get; set; }

        [JsonProperty("index")]
        public string Index { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("result")]
        public SongResult Result { get; set; }
    }

    public class Section
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("hits")]
        public List<TopHit> Hits { get; set; }
    }

    public class SearchRootObject
    {
        [JsonProperty("sections")]
        public List<Section> Sections { get; set; }
    }
}
