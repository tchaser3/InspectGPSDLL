/* Title:           Inspect GPS Class
 * Date:            5-22-20
 * Author:          Terry Holmes
 * 
 * Description:     This used for the GPS Block of the Inspection Form */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace InspectGPSDLL
{
    public class InspectGPSClass
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();

        InspectGPSDataSet aInspectGPSDataSet;
        InspectGPSDataSetTableAdapters.inspectiongpsTableAdapter aInspectGPSTableAdapter;

        InsertInspectGPSEntryTableAdapters.QueriesTableAdapter aInsertInspectGPSTableAdapter;

        FindInspectionGPSByInspectionDataSet aFindInspectionGPSByInspectionDataSet;
        FindInspectionGPSByInspectionDataSetTableAdapters.FindInspectGPSByInspectionTableAdapter aFindInspectionGPSByInspectionTableAdapter;

        public FindInspectionGPSByInspectionDataSet FindInspectionGPSByInspection(int intInspectionID, string strInspectionType)
        {
            try
            {
                aFindInspectionGPSByInspectionDataSet = new FindInspectionGPSByInspectionDataSet();
                aFindInspectionGPSByInspectionTableAdapter = new FindInspectionGPSByInspectionDataSetTableAdapters.FindInspectGPSByInspectionTableAdapter();
                aFindInspectionGPSByInspectionTableAdapter.Fill(aFindInspectionGPSByInspectionDataSet.FindInspectGPSByInspection, intInspectionID, strInspectionType);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inspect GPS Class // Find Inspection GPS By Inspection " + Ex.Message);
            }

            return aFindInspectionGPSByInspectionDataSet;
        }
        public bool InsertInspectGPS(int intInspectionID, string strInspectionType, bool blnGPSInstalled)
        {
            bool blnFatalError = false;

            try
            {
                aInsertInspectGPSTableAdapter = new InsertInspectGPSEntryTableAdapters.QueriesTableAdapter();
                aInsertInspectGPSTableAdapter.InsertInspectGPS(intInspectionID, strInspectionType, blnGPSInstalled);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inspect GPS Class // Insert Inspect GPS " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public InspectGPSDataSet GetInspectGPSInfo()
        {
            try
            {
                aInspectGPSDataSet = new InspectGPSDataSet();
                aInspectGPSTableAdapter = new InspectGPSDataSetTableAdapters.inspectiongpsTableAdapter();
                aInspectGPSTableAdapter.Fill(aInspectGPSDataSet.inspectiongps);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inspect GPS Class // Get Inspect GPS Info " + Ex.Message);
            }

            return aInspectGPSDataSet;
        }
        public void UpdateInspectGPSDB(InspectGPSDataSet aInspectGPSDataSet)
        {
            try
            {
                aInspectGPSTableAdapter = new InspectGPSDataSetTableAdapters.inspectiongpsTableAdapter();
                aInspectGPSTableAdapter.Update(aInspectGPSDataSet.inspectiongps);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inspect GPS Class // Update Inspect GPS DB " + Ex.Message);
            }
        }
    }
}
