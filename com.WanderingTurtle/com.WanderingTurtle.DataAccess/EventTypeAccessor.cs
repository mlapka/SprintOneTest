﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.WanderingTurtle.Common;

namespace com.WanderingTurtle.DataAccess
{
    public class EventTypeAccessor
    {
        //input parameter of EventType, will add the event type to the database, will return a 0 if it fails and a 1 if it was successful (false/true)
        public static int AddEventType(EventType newEventType)
        {
            var conn = DatabaseConnection.GetDatabaseConnection();
            var cmdText = "spInsertEventType";
            var cmd = new SqlCommand(cmdText, conn);
            var rowsAffected = 0;
            //set up parameters for EventType
            cmd.Parameters.AddWithValue("@EventTypeID", newEventType.EventTypeID);
            cmd.Parameters.AddWithValue("@EventName", newEventType.EventName);
            
            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new ApplicationException("Concurrency Violation");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rowsAffected;
        }

        //needs the event object that is having its name being changed and the new name
        //Returns the number of rows affected (should be 1)
        public static int UpdateEventType(EventType oldEventType, EventType newEventType)
        {
            var conn = DatabaseConnection.GetDatabaseConnection();
            var cmdText = "spUpdateEventType";
            var cmd = new SqlCommand(cmdText, conn);
            var rowsAffected = 0;

            // set command type to stored procedure and add parameters
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EventName", newEventType.EventName);

            cmd.Parameters.AddWithValue("@original_EventTypeID", oldEventType.EventName);
            cmd.Parameters.AddWithValue("@original_EventName", oldEventType.EventTypeID);
            
            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new ApplicationException("Concurrency Violation");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rowsAffected;  // needs to be rows affected
        }

        //requires: Event object, Boolean value for active/inactive
        //returns number of rows affected
        public static int DeleteEventType(EventType oldEventType)
        {
            var conn = DatabaseConnection.GetDatabaseConnection();
            var cmdText = "spDeleteEventType";
            var cmd = new SqlCommand(cmdText, conn);
            var rowsAffected = 0;

            cmd.CommandType = CommandType.StoredProcedure;
            //Set up parameters for EventType
            cmd.Parameters.AddWithValue("@original_EventTypeID", oldEventType.EventName);
            cmd.Parameters.AddWithValue("@original_EventName", oldEventType.EventTypeID);
            
            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new ApplicationException("Concurrency Violation");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rowsAffected;  // needs to be rows affected
        }

        //retrieves all EventTypes, Makes a List of EventTypes, Returns the List of EventTypes
        public static List<EventType> GetEventTypeList()
        {
            var EventTypeList = new List<EventType>();

            // set up the database call
            var conn = DatabaseConnection.GetDatabaseConnection();
            string query = "SELECT EventTypeID, EventName "+
            "FROM EventType";
            var cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        var currentEvent = new Event();

                        currentEvent.EventItemID = reader.GetInt32(0);
                        currentEvent.EventItemName = reader.GetString(1);
                        
                    }
                }
                else
                {
                    var ax = new ApplicationException("Data not found!");
                    throw ax;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return EventTypeList;
        }

        //gets an eventTypeID, retrieves data from databases, Returns an Event object
        public static EventType GetEventType(String eventTypeID)
        {
            EventType theEventType = new EventType();
            // set up the database call
            var conn = DatabaseConnection.GetDatabaseConnection();
            string query = "SELECT EventTypeID, EventName" + 
            "FROM EventType WHERE EventTypeID = " + eventTypeID;
            var cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows == true)
                {
                    theEventType.EventTypeID = reader.GetInt32(0);
                    theEventType.EventName = reader.GetString(1);
                    
                }
                else
                {
                    var ax = new ApplicationException("Data not found!");
                    throw ax;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return theEventType;
        }
    }
}
