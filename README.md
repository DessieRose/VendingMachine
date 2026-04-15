# VendingMachine

A console-based vending machine simulator built in C#. Browse items, make purchases, manage your wallet, and restock the machine.

## Features

- **Browse inventory** — view available products and their prices
- **Buy items** — purchase products that go into your backpack
- **Wallet management** — start with a balance and add more money at any time
- **Restock** — refill the machine when products run low
- **Persistent inventory** — stock levels are saved to disk and restored between sessions

## Running the App

```bash
cd FantasticVendingMachine
dotnet run
```

## How It Works

On startup the machine loads its inventory from a local JSON file (or seeds default stock if none exists). Use the numbered menu to interact with the machine. Your purchases are tracked in a backpack you can inspect at any time.
