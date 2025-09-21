# Inizio Search

🚀 **Inizio Search** je webová aplikace postavená na **ASP.NET Core 9.0**.  
Umožňuje vyhledávání přes **Google Programmable Search Engine API** a vrací výsledky ve formátu **JSON** nebo **CSV**.  
Součástí je i jednoduché webové rozhraní (`wwwroot/index.html`).

---

## ✨ Funkce

- 🔎 **Vyhledávání přes API**
  - JSON: seznam výsledků (pozice, název, odkaz, popis).
  - CSV: stejné výsledky jako tabulka (otevřitelné v Excelu).
- 🌐 **Frontend (index.html)**
  - zadání dotazu,
  - zobrazení výsledků v tabulce,
  - možnost stažení výsledků jako CSV.
- ✅ Ukázkové unit testy pro export do CSV.

---

## 🛠️ Použité technologie

- **C# 12 / .NET 9.0**  
- **ASP.NET Core Web API**  
- **Google Programmable Search JSON API**  
- **Frontend:** čistý HTML + JavaScript  
- **Testování:** xUnit  

---

## ▶️ Jak spustit lokálně



### 1. Klonování repozitáře

```bash
git clone https://github.com/Volodymyr2102/inizio-search.git
cd inizio-search/inizio-search¨
```
 

### 2. Nastavení API klíčů
```bash
Vytvoř si vlastní API klíče v Google Cloud / Programmable Search Engine.

export GOOGLE_API_KEY="tvůj_API_klíč"
export GOOGLE_CSE_ID="tvůj_CX"
```


### 3  Spuštění aplikace
```bash
dotnet run
```

### 4. Použití
```bash
JSON: http://localhost:5082/api/search?q=python


CSV: http://localhost:5082/api/search?q=python&format=csv

Frontend: http://localhost:5082/
```

### 5. 🧪 Testy
```bash
dotnet test
```
### 6. 📸 Ukázka

```bash
![Ukázka aplikace](screenshot.png)
```


📌 Autor

Bc Volodymyr Dukhno — junior .NET developer