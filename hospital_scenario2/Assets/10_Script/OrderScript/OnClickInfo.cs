using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickInfo : MonoBehaviour
{
    public GameObject Diagnostic;
    public GameObject Department;
    public GameObject Doctor;
    private bool DiagnosticClick = false;
    private bool DepartmentClick = false;
    private bool DoctorClick = false;

    public void on_click_Diagnostic()
    {
        if(DiagnosticClick)
        {
            DiagnosticClick = false;
            Diagnostic.SetActive(false);
        }
        else
        {
            DiagnosticClick = true;
            Diagnostic.SetActive(true);
        }
    }
    public void on_click_Department()
    {
        if(DepartmentClick)
        {
            DepartmentClick = false;
            Department.SetActive(false);
        }
        else
        {
            DepartmentClick = true;
            Department.SetActive(true);
        }
    }
    public void on_click_Doctor()
    {
        if(DoctorClick)
        {
            DoctorClick = false;
            Doctor.SetActive(false);
        }
        else
        {
            DoctorClick = true;
            Doctor.SetActive(true);
        }
    }
}
