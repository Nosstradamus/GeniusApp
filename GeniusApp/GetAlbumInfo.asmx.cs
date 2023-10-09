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
    /// Summary description for GetAlbumInfo:
    /// getAlbumInfo takes in the id of the Album from the Home/Search method
    /// The API is then called to pull information about that album. This
    /// Information is in the form of a JSON object which must be decoded. 
    /// The desired information is then pulled and stored in an array before
    /// being sent back to Home to be returned to the HTML.
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    //Classes needed to decode the JSON
    public class AlbumData
    {
        public Album album { get; set; }
    }
    public class Album
    {
        public string _type { get; set; }
        public string api_path { get; set; }
        public int comment_count { get; set; }
        public string cover_art_thumbnail_url { get; set; }
        public string cover_art_url { get; set; }
        public object custom_header_image_url { get; set; }
        public string description_preview { get; set; }
        public string full_title { get; set; }
        public string header_image_url { get; set; }
        public int id { get; set; }
        public string lock_state { get; set; }
        public string name { get; set; }
        public string name_with_artist { get; set; }
        public int pyongs_count { get; set; }
        public string release_date { get; set; }
        public ReleaseDateComponents release_date_components { get; set; }
        public string release_date_for_display { get; set; }
        public Album_TrackingPaths tracking_paths { get; set; }
        public string url { get; set; }
        public Album_CurrentUserMetadata current_user_metadata { get; set; }
        public int song_pageviews { get; set; }
        public Album_Artist artist { get; set; }
        public List<CoverArt> cover_arts { get; set; }
        public Album_DescriptionAnnotation description_annotation { get; set; }
        public List<Album_Annotations> annotations { get; set; }
    }

    public class ReleaseDateComponents
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
    }

    public class Album_TrackingPaths
    {
        public string aggregate { get; set; }
        public string concurrent { get; set; }
    }

    public class Album_CurrentUserMetadata
    {
        public List<string> permissions { get; set; }
        public List<string> excluded_permissions { get; set; }
        public Album_Interactions interactions { get; set; }
        public bool pyong { get; set; }
    }

    public class Album_Interactions
    {
        public bool pyong { get; set; }
    }

    public class Album_Artist
    {
        public string _type { get; set; }
        public string api_path { get; set; }
        public string header_image_url { get; set; }
        public int id { get; set; }
        public string image_url { get; set; }
        public string index_character { get; set; }
        public bool is_meme_verified { get; set; }
        public bool is_verified { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string url { get; set; }
        public int iq { get; set; }
    }

    public class CoverArt
    {
        public string _type { get; set; }
        public bool annotated { get; set; }
        public string api_path { get; set; }
        public int id { get; set; }
        public string image_url { get; set; }
        public string thumbnail_image_url { get; set; }
        public string url { get; set; }
        public Album_CurrentUserMetadata current_user_metadata { get; set; }
    }

    public class Album_DescriptionAnnotation
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
        public Album_Range range { get; set; }
        public object song_id { get; set; }
        public string url { get; set; }
        public List<object> verified_annotator_ids { get; set; }
        public Album_CurrentUserMetadata current_user_metadata { get; set; }
        public Album_TrackingPaths tracking_paths { get; set; }
        public string twitter_share_message { get; set; }
        public Album_Annotatable annotatable { get; set; }
        public List<Album_Annotations> annotations { get; set; }
    }

    public class Album_Range
    {
        public string content { get; set; }
    }

    public class Album_Annotatable
    {
        public string _type { get; set; }
        public string api_path { get; set; }
        public string context { get; set; }
        public int id { get; set; }
        public string image_url { get; set; }
        public string link_title { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }

    

    

    

    public class Album_UserAttribution
    {
        public string _type { get; set; }
        public int attribution { get; set; }
        public object pinned_role { get; set; }
        public User user { get; set; }
    }

    public class Album_Annotations
    {
        public string _type { get; set; }
        public string api_path { get; set; }
        public bool being_created { get; set; }
        public Album_Body body { get; set; }
        public int comment_count { get; set; }
        public bool community { get; set; }
        public long created_at { get; set; }
        public String custom_preview { get; set; }
        public bool deleted { get; set; }
        public string embed_content { get; set; }
        public bool has_voters { get; set; }
        public int id { get; set; }
        public bool needs_exegesis { get; set; }
        public bool pinned { get; set; }
        public int? pyongs_count { get; set; }
        public int referent_id { get; set; }
        public string share_url { get; set; }
        public String source { get; set; }
        public string state { get; set; }
        public string twitter_share_message { get; set; }
        public string url { get; set; }
        public bool verified { get; set; }
        public int votes_total { get; set; }
        public Album_CurrentUserMetadata2 current_user_metadata { get; set; }
        public String accepted_by { get; set; }
        public List<Album_Author> authors { get; set; }
        public List<String> cosigned_by { get; set; }
        public Album_CreatedBy created_by { get; set; }
    }

    public class Album_Body
    {
        public string plain { get; set; }
    }

    public class Album_CurrentUserMetadata2
    {
        public List<string> permissions { get; set; }
        public List<string> excluded_permissions { get; set; }
        public Album_Interactions2 interactions { get; set; }
        public object iq_by_action { get; set; }
    }

    public class Album_Interactions2
    {
        public bool cosign { get; set; }
        public bool pyong { get; set; }
        public object vote { get; set; }
    }

    public class Album_Author
    {
        public string _type { get; set; }
        public int attribution { get; set; }
        public object pinned_role { get; set; }
        public Album_User user { get; set; }
    }

    public class Album_User
    {
        public string _type { get; set; }
        public string about_me_summary { get; set; }
        public string api_path { get; set; }
        public Album_Avatar avatar { get; set; }
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
    }

    public class Album_CreatedBy
    {
        public string _type { get; set; }
        public string about_me_summary { get; set; }
        public string api_path { get; set; }
        public Album_Avatar avatar { get; set; }
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
    }


    public class Album_Avatar
    {
        public Album_Tiny tiny { get; set; }
        public Thumb Album_thumb { get; set; }
        public Album_Small small { get; set; }
        public Album_Medium medium { get; set; }
    }

    public class Album_Tiny
    {
        public string url { get; set; }
        public Album_BoundingBox bounding_box { get; set; }
    }

    public class Album_BoundingBox
    {
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Album_Thumb
    {
        public string url { get; set; }
        public BoundingBox1 bounding_box { get; set; }
    }

    public class BoundingBox1
    {
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Album_Small
    {
        public string url { get; set; }
        public BoundingBox2 bounding_box { get; set; }
    }

    public class BoundingBox2
    {
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Album_Medium
    {
        public string url { get; set; }
        public BoundingBox3 bounding_box { get; set; }
    }

    public class BoundingBox3
    {
        public int width { get; set; }
        public int height { get; set; }
    }

    public class GetAlbumInfo : System.Web.Services.WebService
    {

        [WebMethod]
        public string[] getAlbumInfo(string id)
        {   
            //Create client using API link
            var client = new RestClient("https://genius-song-lyrics1.p.rapidapi.com/album/details/?id="+id+"&text_format=plain");
            //Create Request adding in Key and Host Credentials.
            var request = new RestRequest();
            request.AddHeader("X-RapidAPI-Key", "85e567e6c5msh78b9419bc244368p122c01jsn1738bee94e5a");
            request.AddHeader("X-RapidAPI-Host", "genius-song-lyrics1.p.rapidapi.com");
            //Gather Response
            RestResponse response = client.Execute(request);
            
            String[] result = new string[4];
            try
            {

                //Decode response to new object using classes defined above
                AlbumData album = JsonConvert.DeserializeObject<AlbumData>(response.Content);

                
                //pull relevant data
                result[0] = "Artist:" + album.album.artist.name;
                result[1] = album.album.cover_art_thumbnail_url;
                result[2] = "Release Date: " + album.album.release_date;
                result[3] = "Description: " + album.album.description_preview;

            }
            catch (Exception e)
            {
                //Catch any exceptions 
                result[0] = "An error was encountered";
                Console.WriteLine(e.Message);
            }
            //return
            return result;
        }
    }
}
