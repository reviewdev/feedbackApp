using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCOnline.API.DataAccessLayer;
using TCOnline.API.Models;

namespace TCOnline.API.Controllers
{
    public class ReviewController : ApiController
    {
        #region CRUD Feedback Records
        // GET: all feedback record  
            /// <summary>
            /// Get All the feedback records 
            /// </summary>
            /// <returns> List of Feedbacks</returns>
        [System.Web.Http.HttpGet]
        public List<FeedbackDetail_DTO> GetAllFeedbacks()
        {
            List<FeedbackDetail> feedbackDALList = DAL.GetAllFeedbacks();
            List<FeedbackDetail_DTO> feedbackApiList = new List<FeedbackDetail_DTO>();

            foreach (var item in feedbackDALList)
            {
                FeedbackDetail_DTO feedApi = new FeedbackDetail_DTO();
                feedApi.Id = item.Id;
                feedApi.Rating = (int)item.Rating;
                if (!string.IsNullOrEmpty(item.Comment))
                    feedApi.Comment = item.Comment;
                feedbackApiList.Add(feedApi);
            }

            return feedbackApiList;
        }

        // Get one feedback
        /// <summary>
        /// Find one specific Feedback record
        /// </summary>
        /// <param name="id">database generated PK</param>
        /// <returns> Feedback record</returns>

        [System.Web.Http.HttpGet]
        public FeedbackDetail_DTO FindFeedback(int id)
        {
            FeedbackDetail feedDAL = DAL.FindFeedback(id);
            FeedbackDetail_DTO feedApi = new FeedbackDetail_DTO();
            if (feedDAL != null)
            {
                feedApi.Id = feedDAL.Id;
                feedApi.Rating = (int)feedDAL.Rating;
                if (!string.IsNullOrEmpty(feedDAL.Comment))
                    feedApi.Comment = feedDAL.Comment;

            }
            return feedApi;
        }

        // Create one Feedback
        /// <summary>
        /// Create one Feedback record
        /// </summary>
        /// <param name="feedApi"> pass from form viewModel to API</param>
        /// <returns>True or False</returns>
        [System.Web.Http.HttpPost]
        public bool InsertFeedback(FeedbackDetail_DTO feedApi)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                FeedbackDetail feedDAL = new FeedbackDetail();

                feedDAL.Rating = (int)feedApi.Rating;
                if (!string.IsNullOrEmpty(feedApi.Comment))
                    feedDAL.Comment = feedApi.Comment;
                status = DAL.InsertFeedback(feedDAL);
            }
            return status;
        }

        // find all the Rateing Types
        /// <summary>
        /// Find all the available Rating types
        /// </summary>
        /// <returns> a sting </returns>
        [System.Web.Http.HttpGet]
        public string GetAllRatingTypes()
        {
            List<FeedbackDetail> feedbackDALList = DAL.GetAllFeedbacks();
          
            var tempDetails = feedbackDALList.OrderBy(c => c.Rating).ToList();
            var tempTypes = tempDetails.Select(c => c.Rating).ToList().Distinct();

            string types = "";          
            if(tempTypes.Any())
            {
                foreach(var item in tempTypes)
                {
                    types = types + item.ToString() + " ";
                }
            }

            return types;
        } // end of method
        #endregion

    } // end of class
    }