using System;
using System.Numerics;
using System.ComponentModel;
using System.Diagnostics;
using DGD203_2;

public class Map
{
	private Game _theGame;

	private Vector2 _coordinates;

	private int[] _widthBoundaries;
	private int[] _heightBoundaries;

	private Location[] _locations;


	public Map(Game game, int width, int height)
	{
		_theGame = game;

		// Setting the width boundaries
		int widthBoundary = (width - 1) / 2;

        _widthBoundaries = new int[2];
        _widthBoundaries[0] = -widthBoundary;
		_widthBoundaries[1] = widthBoundary;

		// Setting the height boundaries
        int heightBoundary = (height - 1) / 2;

        _heightBoundaries = new int[2];
		_heightBoundaries[0] = -heightBoundary;
		_heightBoundaries[1] = heightBoundary;

		// Setting starting coordinates
        _coordinates = new Vector2(0,0);

		GenerateLocations();

		// Display result message
		Console.WriteLine($"Created map with size {width}x{height}");
    }

    #region Coordinates

    public Vector2 GetCoordinates()
	{
		return _coordinates;
	}

	public void SetCoordinates(Vector2 newCoordinates)
	{
		_coordinates = newCoordinates;
	}

	#endregion

	#region Movement

	public void MovePlayer(int x, int y)
	{
		int newXCoordinate = (int)_coordinates[0] + x;
        int newYCoordinate = (int)_coordinates[1] + y;

		if (!CanMoveTo(newXCoordinate, newYCoordinate)) 
		{
            Console.WriteLine("You can't go that way");
            return;
        }

		_coordinates[0] = newXCoordinate;
		_coordinates[1] = newYCoordinate;

		CheckForLocation(_coordinates);
    }

	private bool CanMoveTo(int x, int y)
	{
		return !(x < _widthBoundaries[0] || x > _widthBoundaries[1] || y < _heightBoundaries[0] || y > _heightBoundaries[1]);
	}

	#endregion

	#region Locations

	private void GenerateLocations()
	{
        _locations = new Location[6];

        Vector2 ankaraLocation = new Vector2(0, 0);
		List<Item> ankaraItems = new List<Item>();
        ankaraItems.Add(Item.Coin);
        Location ankara = new Location("Ankara", LocationType.City, ankaraLocation, ankaraItems);
        _locations[0] = ankara;

        Vector2 izmirLocation = new Vector2(-2, 2);
		List<Item> izmirItems = new List<Item>();
        izmirItems.Add(Item.Charm);
        Location izmir = new Location("Izmir", LocationType.City, izmirLocation, izmirItems);
        _locations[1] = izmir;

        Vector2 aydinLocation = new Vector2(1, -2);
		List<Item> aydinItems = new List<Item>();
        aydinItems.Add(Item.Rune);
        Location aydin = new Location("Aydin", LocationType.City, aydinLocation, aydinItems);
        _locations[2] = aydin;

        Vector2 roseLocation = new Vector2(1, 1);
        Location rose = new Location("Rose", LocationType.City, roseLocation);
        _locations[3] = rose;

		Vector2 firstCombatLocation = new Vector2(-2, 1);
		Location firstCombat = new Location("First Combat", LocationType.Combat, firstCombatLocation);
		_locations[4] = firstCombat;


        Vector2 npcLocation = new Vector2(-1, -1);
        Location npcConv = new Location("Conversation", LocationType.Npc, npcLocation);
        _locations[5] = npcConv;

    }

	public void CheckForLocation(Vector2 coordinates)
	{
        Console.WriteLine($"You are now standing on {_coordinates[0]},{_coordinates[1]}");

        if (IsOnLocation(_coordinates, out Location location))
        {
            if (location.Type == LocationType.Combat)
			{
				if (location.EventAlreadyHappened) return;

				Console.WriteLine("Prepare to fight!");
				Combat combat = new Combat(_theGame, location);

				combat.StartCombat();

			} 
			else if (location.Type == LocationType.Npc)
			{
                if (location.EventAlreadyHappened) return;

                Console.WriteLine("Hello stranger, what are you doing around here?");
                Console.WriteLine("While I met you, I have a very good question for you.");
                Npc npc = new Npc(_theGame, location);

                npc.StartConv();
            }
			else
			{
				Console.WriteLine($"You are in {location.Name} {location.Type}");

				if (HasItem(location))
				{
					Console.WriteLine($"There is a {location.ItemsOnLocation[0]} here");
				}
			}

        }
    }

	private bool IsOnLocation(Vector2 coords, out Location foundLocation)
	{
		for (int i = 0; i < _locations.Length; i++)
		{
			if (_locations[i].Coordinates == coords)
			{
				foundLocation = _locations[i];
				return true;
			}
		}

		foundLocation = null;
		return false;
	}

	private bool HasItem(Location location)
	{
		return location.ItemsOnLocation.Count != 0;

		// ---- THE LONG FORM ----
		//if (location.ItemsOnLocation.Count == 0)
		//{
		//	return false;
		//} else
		//{
		//	return true;
		//}
	}

	public void TakeItem(Location location)
	{

	}

	public void TakeItem(Player player, Vector2 coordinates)
	{
		if (IsOnLocation(coordinates, out Location location))
		{
			if (HasItem(location))
			{
				Item itemOnLocation = location.ItemsOnLocation[0];

				player.TakeItem(itemOnLocation);
				location.RemoveItem(itemOnLocation);

				Console.WriteLine($"You took the {itemOnLocation}");

				return;
			}
		}

		Console.WriteLine("There is nothing to take here!");
	}

	public void RemoveItemFromLocation(Item item)
	{
		for (int i = 0; i < _locations.Length; i++)
		{
			if (_locations[i].ItemsOnLocation.Contains(item))
			{
				_locations[i].RemoveItem(item);
			}
		}
	}

	#endregion
}