using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Used to create personalized user profiles
public class Profile {

    public int userID;
    public string userName;

    //Constructor for CREATING the user
    public Profile(int userID, string userName, Texture userImage)
    {
        this.userID = userID;
        this.userName = userName;
    }

    //Returns the profile of the user
    public Profile GetProfile() => this;
}
