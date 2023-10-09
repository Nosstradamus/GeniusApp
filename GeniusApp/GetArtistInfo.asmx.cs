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
    /// Summary description for GetArtistInfo:
    /// Takes ID string and passes to API. Gets resulting JSON
    /// object. Decodes using defined classes. Pass desired fields 
    /// in array.
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    
    //Class needed to decode JSON
    public class RootObject
    {
        public Artist artist { get; set; }
    }

    public class Artist
    {
        public string _type { get; set; }
        public List<string> alternate_names { get; set; }
        public string api_path { get; set; }
        public Description description { get; set; }
        public string description_preview { get; set; }
        public string facebook_name { get; set; }
        public int followers_count { get; set; }
        public string header_image_url { get; set; }
        public int id { get; set; }
        public string image_url { get; set; }
        public string index_character { get; set; }
        public string instagram_name { get; set; }
        public bool is_meme_verified { get; set; }
        public bool is_verified { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public TrackingPaths tracking_paths { get; set; }
        public bool translation_artist { get; set; }
        public string twitter_name { get; set; }
        public string url { get; set; }
        public CurrentUserMetadata current_user_metadata { get; set; }
        public int iq { get; set; }
        public DescriptionAnnotation description_annotation { get; set; }
        public User user { get; set; }
    }

    public class Description
    {
        public string html { get; set; }
    }

    public class TrackingPaths
    {
        public string aggregate { get; set; }
        public string concurrent { get; set; }
    }
    public class Annotatable
    {
        public string _type { get; set; }
        public string api_path { get; set; }
        public object context { get; set; }
        public int id { get; set; }
        public string image_url { get; set; }
        public string link_title { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }

    public class CurrentUserMetadata
    {
        public List<string> permissions { get; set; }
        public List<string> excluded_permissions { get; set; }
        public Interactions interactions { get; set; }
    }

    public class Interactions
    {
        public bool following { get; set; }
    }

    public class DescriptionAnnotation
    {
        public string _type { get; set; }
        public int annotator_id { get; set; }
        public string annotator_login { get; set; }
        public string api_path { get; set; }
        public string classification { get; set; }
        public string fragment { get; set; }
        public int id { get; set; }
        public string ios_app_url { get; set; }
        public bool is_description { get; set; }
        public bool is_image { get; set; }
        public string path { get; set; }
        public Range range { get; set; }
        public object song_id { get; set; }
        public string url { get; set; }
        public List<object> verified_annotator_ids { get; set; }
        public CurrentUserMetadata current_user_metadata { get; set; }
        public TrackingPaths tracking_paths { get; set; }
        public string twitter_share_message { get; set; }
        public Annotatable annotatable { get; set; }
        public List<Annotation> annotations { get; set; }
        //public User user { get; set; }
    }

    public class Range
    {
        public string content { get; set; }
    }

    public class Annotation
    {
        public string _type { get; set; }
        public string api_path { get; set; }
        public bool being_created { get; set; }
        public Body_Artist body { get; set; }
        public int comment_count { get; set; }
        public bool community { get; set; }
        public int created_at { get; set; }
        public object custom_preview { get; set; }
        public bool deleted { get; set; }
        public string embed_content { get; set; }
        public bool has_voters { get; set; }
        public int id { get; set; }
        public bool needs_exegesis { get; set; }
        public bool pinned { get; set; }
        public int proposed_edit_count { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int pyongs_count { get; set; }
        public int referent_id { get; set; }
        public string share_url { get; set; }
        public object source { get; set; }
        public string state { get; set; }
        public string twitter_share_message { get; set; }
        public string url { get; set; }
        public bool verified { get; set; }
        public int votes_total { get; set; }
        public CurrentUserMetadata current_user_metadata { get; set; }
        public object accepted_by { get; set; }
        public List<Author> authors { get; set; }
        public List<object> cosigned_by { get; set; }
        public CreatedBy created_by { get; set; }
        public object rejection_comment { get; set; }
        public object top_comment { get; set; }
        public object verified_by { get; set; }
    }

    public class Body_Artist
    {
        public string html { get; set; }
    }

    public class Author
    {
        public UserAttribution user_attribution { get; set; }
        public object pinned_role { get; set; }
        public User user { get; set; }
    }

    public class UserAttribution
    {
        public int attribution { get; set; }
    }

    public class CreatedBy
    {
        public string _type { get; set; }
        public string about_me_summary { get; set; }
        public string api_path { get; set; }
        public Avatar avatar { get; set; }
        public string header_image_url { get; set; }
        public string human_readable_role_for_display { get; set; }
        public int id { get; set; }
        public int iq { get; set; }
        public bool is_meme_verified { get; set; }
        public bool is_verified { get; set; }
        public string login { get; set; }
        public string name { get; set; }
        public string role_for_display { get; set; }
        public string url { get; set; }
        public CurrentUserMetadata current_user_metadata { get; set; }
    }

    public class User
    {
        public string _type { get; set; }
        public string about_me_summary { get; set; }
        public string api_path { get; set; }
        public Avatar avatar { get; set; }
        public string header_image_url { get; set; }
        public string human_readable_role_for_display { get; set; }
        public int id { get; set; }
        public int iq { get; set; }
        public bool is_meme_verified { get; set; }
        public bool is_verified { get; set; }
        public string login { get; set; }
        public string name { get; set; }
        public string role_for_display { get; set; }
        public string url { get; set; }
        public CurrentUserMetadata current_user_metadata { get; set; }
    }

    public class Avatar
    {
        public Tiny tiny { get; set; }
        public Thumb thumb { get; set; }
        public Small small { get; set; }
        public Medium medium { get; set; }
    }

    public class Tiny
    {
        public string url { get; set; }
        public BoundingBox bounding_box { get; set; }
    }

    public class BoundingBox
    {
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Thumb
    {
        public string url { get; set; }
        public BoundingBox bounding_box { get; set; }
    }

    public class Small
    {
        public string url { get; set; }
        public BoundingBox bounding_box { get; set; }
    }

    public class Medium
    {
        public string url { get; set; }
        public BoundingBox bounding_box { get; set; }
    }
    public class GetArtistInfo : System.Web.Services.WebService
    {

        [WebMethod]
        public string[] getArtistInfo(String artistId)
        {   
            //Create client with API link
            var client = new RestClient("https://genius-song-lyrics1.p.rapidapi.com/artist/details/?id=" + artistId + "&text_format=plain",
                configureSerialization: s => s.UseNewtonsoftJson());
            //Create request with key and host strings
            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", "85e567e6c5msh78b9419bc244368p122c01jsn1738bee94e5a");
            request.AddHeader("X-RapidAPI-Host", "genius-song-lyrics1.p.rapidapi.com");
            //Gather Response
            RestResponse response = client.Execute(request);
            //Decode JSON using defined classes
            RootObject root = JsonConvert.DeserializeObject<RootObject>(response.Content);
            //Gather desired info, pack into Array and return
            String description = root.artist.description_preview;
            String artistUrl = root.artist.image_url;

            String[] result = new string[4];
            try
            {
                result[0] = "Name: " + root.artist.name;
                result[1] = artistUrl;
                result[2] = "Description: " + description;
                result[3] = "";
            }
            catch (Exception e)
            {
                //Catch any exceptions 
                result[0] = "An error was encountered";
                Console.WriteLine(e.Message);
            }
            return result;
        }
    }
}
