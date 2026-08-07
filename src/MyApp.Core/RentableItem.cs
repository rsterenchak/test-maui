/*
 * This file defines a single rentable item in Ridgeline Outfitters' gear
 * catalog: one piece of equipment the counter staff can rent out and take back.
 * Each item carries a unique identifier used to look it up, a display name shown
 * at the counter, the rate charged per day it is rented, and a flag recording
 * whether it is currently out on rental. This class only holds that data and
 * guards access to it through accessors and mutators; the rent and return
 * operations that read and flip the rented flag live elsewhere in the catalog.
 *
 * Robert Sterenchak
 * August 7, 2026
 */

namespace MyApp.Core;

public class RentableItem
{
    //instance variables
    private string itemId = "";//unique identifier used to look the item up
    private string name = "";//display name shown to counter staff
    private decimal dailyRate = 0m;//amount charged per day the item is rented
    private bool isRented = false;//true while the item is out on rental

    /** Constructors */

    //Constructor that builds a rentable item from its identifier, name, and daily rate, starting available.
    public RentableItem(string newItemId, string newName, decimal newDailyRate)
    {
        this.setItemId(newItemId);//delegate to setter so any later validation applies at construction too
        this.setName(newName);//delegate to setter
        this.setDailyRate(newDailyRate);//delegate to setter
        this.setIsRented(false);//a freshly catalogued item is always available
    }//ends constructor

    /** Accessor Methods */

    //Get function returns the item's unique identifier.
    public string getItemId()
    {
        return this.itemId;//current identifier
    }//end of getItemId

    //Get function returns the item's display name.
    public string getName()
    {
        return this.name;//current display name
    }//end of getName

    //Get function returns the item's daily rental rate.
    public decimal getDailyRate()
    {
        return this.dailyRate;//current daily rate
    }//end of getDailyRate

    //Get function returns whether the item is currently rented out.
    public bool getIsRented()
    {
        return this.isRented;//current rented flag
    }//end of getIsRented

    /** Mutator Methods */

    //Set function stores the item's unique identifier.
    public void setItemId(string newItemId)
    {
        this.itemId = newItemId;//store new identifier
    }//end of setItemId

    //Set function stores the item's display name.
    public void setName(string newName)
    {
        this.name = newName;//store new display name
    }//end of setName

    //Set function stores the item's daily rental rate.
    public void setDailyRate(decimal newDailyRate)
    {
        this.dailyRate = newDailyRate;//store new daily rate
    }//end of setDailyRate

    //Set function stores whether the item is currently rented out.
    public void setIsRented(bool newIsRented)
    {
        this.isRented = newIsRented;//store new rented flag
    }//end of setIsRented

    /** toString Method */

    //toString function returns a one-line summary of the item for display in listings.
    public override string ToString()
    {
        string status = this.isRented ? "rented" : "available";//word form of the rented flag for the reader
        return $"{this.itemId}: {this.name} (${this.dailyRate:0.00}/day) - {status}";//identifier, name, rate, and status on one line
    }//end of ToString
}//end of RentableItem
