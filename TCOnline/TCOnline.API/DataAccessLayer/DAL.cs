using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCOnline.API.DataAccessLayer
{
    public class DAL
    {
       
            static ABCEntitiesOfTC DbContext;
            static DAL()
            {
                DbContext = new ABCEntitiesOfTC();
            }

            #region Users Information
            // Get all user information
            public static List<User> GetAllUsers()
            {
                return DbContext.Users.ToList();
            }

            // find the login in user
            public static bool FindUser(string username, string password)
            {
                var userDetail = DbContext.Users.Where(
                        x => x.UserName.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
                if (userDetail != null)
                    return true;
                else
                    return false;
            }

            #endregion

            #region Feedback Information

            // Get all the feedback
            public static List<FeedbackDetail> GetAllFeedbacks()
            {
                return DbContext.FeedbackDetails.ToList();
            }




            //Get ONE specific feedback information 
            public static FeedbackDetail FindFeedback(int Id)
            {
                return DbContext.FeedbackDetails.Where(p => p.Id == Id).FirstOrDefault();
            }
            // Create One New Feedback record into database 
            public static bool InsertFeedback(FeedbackDetail feedback)
            {
                bool status;
                try
                {
                    DbContext.FeedbackDetails.Add(feedback);
                    DbContext.SaveChanges();
                    status = true;
                }
                catch (Exception e)
                {
                    status = false;
                }
                return status;
            }

            // Update One existed Feedback record
            public static bool UpdateFeedback(FeedbackDetail feedback)
            {
                bool status;
                try
                {
                    FeedbackDetail Item = DbContext.FeedbackDetails.Where(p => p.Id == feedback.Id).FirstOrDefault();
                    if (Item != null)
                    {
                        Item.Rating = feedback.Rating;
                        if (!string.IsNullOrEmpty(feedback.Comment))
                            Item.Comment = feedback.Comment;
                        DbContext.SaveChanges();
                    }
                    status = true;
                }
                catch (Exception)
                {
                    status = false;
                }
                return status;
            }

            //Delete One Specific Feedback Record
            public static bool DeleteFeedback(int id)
            {
                bool status;
                try
                {
                    FeedbackDetail Item = DbContext.FeedbackDetails.Where(p => p.Id == id).FirstOrDefault();
                    if (Item != null)
                    {
                        DbContext.FeedbackDetails.Remove(Item);
                        DbContext.SaveChanges();
                    }
                    status = true;
                }
                catch (Exception)
                {
                    status = false;
                }
                return status;
            }
            #endregion
        } // end of class
    }