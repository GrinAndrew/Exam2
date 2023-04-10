using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam2.Data;
using System.Linq;

namespace Exam2.Model
{
    public static class DBManager
    {
        // 
        public static Users GetUserByID(int ID)
        {
            using (SQLContext db = new SQLContext())
            {
                Users Usr = db.Users.FirstOrDefault(usr => usr.ID == ID);
                return Usr;
            }
        }
        public static Applications GetAppByID(int ID)
        {
            using (SQLContext db = new SQLContext())
            {
                Applications App = db.Applications.FirstOrDefault(app => app.ID == ID);
                return App;
            }
        }
        // comments list
        public static List<Comments> GetAllComments()
        {
            using (SQLContext db = new SQLContext())
            {
                var result = db.Comments.ToList();
                return result;
            }
        }
        // add comment
        public static int CreateComment(string TextComment, Users UserComment, Applications AppComment)
        {
            int result = 0;

            using (SQLContext db = new SQLContext())
            {
                {
                    Comments newComment = new Comments();
                    newComment.ApplicationID = AppComment.ID;
                    newComment.UserID = UserComment.ID;
                    newComment.CommentText = TextComment;

                    db.Comments.Add(newComment);
                    db.SaveChanges();
                    result = 1;
                }
            }
            return result;
        }
        // delete comment
        public static int DeleteComment(Comments Comment)
        {
            int result = 0;

            using (SQLContext db = new SQLContext())
            {
                db.Comments.Remove(Comment);
                db.SaveChanges();
                result = 1;
            }

            return result;
        }
        // update comment
        public static int EditComment(Comments Comment, Applications CommentApp, Users CommentUser, string? NewText)
        {
            int result = 0;

            using (SQLContext db = new SQLContext())
            {
                Comments? prevComm = db.Comments.FirstOrDefault(comm => comm.ID == Comment.ID);
                if (prevComm != null)
                {
                    prevComm.CommentText = NewText;
                    prevComm.Application = CommentApp;
                    prevComm.User = CommentUser;

                    db.Comments.Update(prevComm);
                    db.SaveChanges();
                    result = 1;
                }
            }
            return result;

        }

        //  Users list
        public static List<Users> GetAllUsers()
        {
            using (SQLContext db = new SQLContext())
            {
                var result = db.Users.ToList();
                return result;
            }
            
        }
        // add User
        public static int CreateUser(string Name)
        {
            using (SQLContext db = new SQLContext())
            {
                bool IsExists = db.Users.Any(usr => usr.Name == Name);
                if (!IsExists)
                {
                    Users newUser = new Users { Name = Name };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    return 1;
                }
            }

            return 0;
        }

        // update User
        public static int EditeUser(Users User, string NewName)
        {
            int result = 0;

            using (SQLContext db = new SQLContext())
            {
                Users? prevUser = db.Users.FirstOrDefault(usr => usr.ID == User.ID);
                if (prevUser != null)
                {
                    prevUser.Name = NewName;
                    db.Users.Update(prevUser);
                    db.SaveChanges();
                    result = 1;
                }
            }
            return result;

        }

        // delete User
        public static int DeleteUser(Users User)
        {
            int result = 0;

            using (SQLContext db = new SQLContext())
            {
                try
                {
                    db.Users.Remove(User);
                    db.SaveChanges();
                    result = 1;
                }
                catch
                {
                    result = 0;
                }
            }
            return result;
        }

        // Apps list
        public static List<Applications> GetAllApplications()
        {
            using (SQLContext db = new SQLContext())
            {
                var result = db.Applications.ToList();
                return result;
            }
        }

        // add App
        public static int CreateApplication(string Name)
        {
            using (SQLContext db = new SQLContext())
            {
                bool IsExists = db.Applications.Any(app => app.Name == Name);
                if (!IsExists)
                {
                    Applications newApp = new Applications { Name = Name };
                    db.Applications.Add(newApp);
                    db.SaveChanges();
                    return 1;
                }
                else return 0;
            }
        }
        // update App
        public static int EditApplication(Applications App, string NewName)
        {
            int result = 0;

            using (SQLContext db = new SQLContext())
            {
                Applications? prevApp = db.Applications.FirstOrDefault(app => app.ID == App.ID);
                if (prevApp != null)
                {
                    prevApp.Name = NewName;
                    db.Applications.Update(prevApp);
                    db.SaveChanges();
                    result = 1;
                }
            }
            return result;

        }

        // delete App
        public static int DeleteApplication(Applications App)
        {
            int result = 0;

            using (SQLContext db = new SQLContext())
            {
                try
                {
                    db.Applications.Remove(App);
                    db.SaveChanges();
                    result = 1;
                }
                catch 
                {
                    result = 0;
                }

            }
            return result;

        }
    }
}
