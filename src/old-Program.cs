using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Projeto {
    class main {
        //Data
        string[][] weapons = new string[4][]; string[] enemyStats = new string[3];
        string[][] inventory = new string[10][];
        private Random ale = new Random();
        private string dayCycle, txt;
        private bool a = true, isRunning = true, debugMode = false;
        private int currentInventorySlot, currentWeaponSlot, life, lifeMax, stamina, staminaMax, strength, choice, level, levelProgress, levelMax, currentTime, timeMax, dayProgress, numbBox, numbBox1;
        private void Start() {
            Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine("----------------------------------------\r\nSoftware deselvolvido por Gustavo Keyzo Saiki N16 1B\r\nBom jogo!!!\r\n----------------------------------------\r\n");
            life = lifeMax = stamina = staminaMax = levelMax = 100; strength = 5; dayCycle = "dia"; timeMax = 5; dayProgress = level = levelProgress = currentTime = 1;
            currentWeaponSlot = currentInventorySlot = 0;
            for (int i = 0; i <= 9; i++) {
                if (i <= 3) { weapons[i] = new string[5]; }
                if (i <= 10) { inventory[i] = new string[2]; }
            }
            Choice();
        }
        private void Choice() {
            while (isRunning == true) {
                DayCycle(false);
            init:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                if (dayCycle == "dia") {
                    txt = "dia";
                }
                else {
                    txt = "noite";
                }
                if (stamina < (staminaMax / 10) & StaminaRecover() == false) {
                    Console.Write("Você está extremamente cançado!!! Tente achar uma maneira de se recuperar ou você será derrotado!!!\r\n");
                }
                switch (CheckChoice(ConsoleColor.DarkGreen, txt)) {
                    default:
                        Console.WriteLine(""); WrongChoice(); goto init;
                    case 1:
                        Console.Clear();
                        Events();
                        break;
                    case 2:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Weapons();
                        break;
                    case 3:
                        Console.Clear();
                        Inventory(ConsoleColor.DarkCyan);
                        break;
                    case 4:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Status(); Console.Write("\r\n----------------------------------------\r\n\r\n");
                        break;
                    case 5:
                        Console.Clear();
                        if (dayCycle == "noite") {
                            Console.Write("Você dormiu! Estamina recuperada!\r\n"); stamina = staminaMax;
                            DayCycle(true);
                        }
                        else {
                            Console.Clear(); Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.Write("----------------------------------------\r\nEsse software foi feito por: Gustavo Keyzo Saiki N16 1B\r\nCom a finalidade de fazer uma lição da matéria de TPA :))\r\n----------------------------------------\r\n\r\n");
                        }
                        break;
                    case 6:
                        if (dayCycle == "noite") {
                            Console.Clear(); Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.Write("----------------------------------------\r\nEsse software foi feito por: Gustavo Keyzo Saiki N16 1B\r\nCom a finalidade de fazer uma lição da matéria de TPA :))\r\n----------------------------------------\r\n\r\n");
                        }
                        else {
                            return;
                        }
                        break;
                    case 7:
                        if (dayCycle == "noite") {
                            return;
                        }
                        else {
                            WrongChoice(); goto init;
                        }
                    case 2684:
                        Debug();
                        goto init;
                }
            }
        }
        private void Events() {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            currentTime++;
            numbBox = ale.Next(0, 101);
            if (numbBox <= 25) {
                if (currentInventorySlot == 10) { Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("----------------------------------------\r\nVocê deixou de pegar um item porque seu inventário está cheio!!\r\n----------------------------------------\r\n"); }
                else {
                    if (numbBox <= 15) {
                        //Normal Potion and Super Potion
                        if (numbBox <= 10) {
                            Console.Write("----------------------------------------\r\nVocê achou uma [Poção de Vida] que recupera " + (lifeMax / 4) + " de vida!\r\n----------------------------------------\r\n\r\n");
                            inventory[currentInventorySlot][0] = "Poção de Vida";
                            inventory[currentInventorySlot][1] = Convert.ToString(lifeMax / 4); currentInventorySlot++;
                        }
                        else {
                            Console.Write("----------------------------------------\r\nVocê achou uma [Super Poção de Vida] que recupera " + (lifeMax / 2) + " de vida!\r\n----------------------------------------\r\n\r\n");
                            inventory[currentInventorySlot][0] = "Super Poção de Vida";
                            inventory[currentInventorySlot][1] = Convert.ToString(lifeMax / 2); currentInventorySlot++;
                        }
                        Choice();
                    }
                    else if (numbBox <= 25) {
                        //Stamina Potion and Super Stamina Potion
                        if (numbBox <= 20) {
                            Console.Write("----------------------------------------\r\nVocê achou uma [Poção de Estamina] que recupera " + (staminaMax / 2) + " de estamina!\r\n----------------------------------------\r\n\r\n");
                            inventory[currentInventorySlot][0] = "Poção de Estamina";
                            inventory[currentInventorySlot][1] = Convert.ToString(staminaMax / 2); currentInventorySlot++;
                        }
                        else {
                            Console.Write("----------------------------------------\r\nVocê achou uma [Super Poção de Estamina] que recupera " + staminaMax + " de estamina!\r\n----------------------------------------\r\n\r\n");
                            inventory[currentInventorySlot][0] = "Super Poção de Estamina";
                            inventory[currentInventorySlot][1] = Convert.ToString(staminaMax); currentInventorySlot++;
                        }
                    }
                }
            }
            else if (numbBox <= 50) {
                if (currentWeaponSlot == 4) {
                    Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("----------------------------------------\r\nVocê deixou de pegar uma arma porque sua bolsa está cheia!!\r\n----------------------------------------\r\n\r\n"); ;
                }
                else {
                    numbBox = ale.Next(0, 101);
                    if (numbBox <= 75) {
                        Console.Write("----------------------------------------\r\nVocê achou uma [Espada]! De uma checada nela em \"Ver Armas\"!\r\n----------------------------------------\r\n\r\n");
                        weapons[currentWeaponSlot][0] = "Espada"; weapons[currentWeaponSlot][1] = Convert.ToString(ale.Next(strength + 13, strength + 20));
                        weapons[currentWeaponSlot][2] = Convert.ToString(ale.Next(staminaMax / 10, staminaMax / 8)); weapons[currentWeaponSlot][3] = Convert.ToString(ale.Next(1, 21));
                        weapons[currentWeaponSlot][4] = "20"; currentWeaponSlot++;
                    }
                    else if (numbBox <= 99) {
                        Console.Write("----------------------------------------\r\nVocê achou um [Soco Ingles], de uma checada nele em \"Ver Armas\"!\r\n----------------------------------------\r\n\r\n");
                        weapons[currentWeaponSlot][0] = "Soco Ingles"; weapons[currentWeaponSlot][1] = Convert.ToString(ale.Next(strength + 11, strength + 15));
                        weapons[currentWeaponSlot][2] = Convert.ToString(ale.Next(staminaMax / 12, staminaMax / 10)); weapons[currentWeaponSlot][3] = Convert.ToString(ale.Next(1, 26));
                        weapons[currentWeaponSlot][4] = "25"; currentWeaponSlot++;
                    }
                    else {
                        Console.Write("----------------------------------------\r\nVocê achou a [Excalibur], de uma checada nessa arma lendária em \"Ver Armas\"!\r\n----------------------------------------\r\n\r\n");
                        weapons[currentWeaponSlot][0] = "Excalibur"; weapons[currentWeaponSlot][1] = Convert.ToString(ale.Next(strength * 5, strength * 10));
                        weapons[currentWeaponSlot][2] = Convert.ToString(staminaMax / 2); weapons[currentWeaponSlot][3] = "1";
                        weapons[currentWeaponSlot][4] = "1"; currentWeaponSlot++;
                    }
                }
            }
            else if (numbBox <= 92) {
                Enemy(false);
                Battle();
            }
            else {
                Console.Write("----------------------------------------\r\nVocê achou uma [Poção de Nivel], você a toma e assim seu nivel fica: " + (level + 1) + "\r\n"); levelProgress = levelMax;
                LevelUp();
            }
        }
        private void Battle() {
        init:
            if (life <= 0) {
                Console.Write("Você morreu!!! Até a próxima :(\r\n");
                isRunning = false; Console.Read();
            }
            else if (stamina < staminaMax / 10 & StaminaRecover() == false) {
                Console.Write("Você está extremamente cançado, e por estar em uma luta, você é derrotado pelo " + enemyStats[0]); isRunning = false;
            }
            else {
                switch (CheckChoice(ConsoleColor.Red, "battle")) {
                    default:
                        WrongChoice(); Console.ForegroundColor = ConsoleColor.Red; goto init;
                    case 1:
                        Console.Clear();
                    init1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        numbBox = -1;
                        a = true; numbBox1 = CheckChoice(ConsoleColor.Red, "battleActionChoice");
                        if (numbBox1 > 0 & numbBox1 <= currentWeaponSlot + 2) {
                            Console.Clear();
                            if (numbBox1 == currentWeaponSlot + 2) {
                                goto init;
                            }
                            else if (numbBox1 == currentWeaponSlot + 1) {
                                if (stamina >= strength + 5) {
                                    Console.Write("----------------------------------------\r\nVocê socou o " + enemyStats[0] + ", o causou -" + strength + " de dano e você perdeu -" + (stamina / 7) + " de estamina!\r\n");
                                    enemyStats[1] = Convert.ToString(int.Parse(enemyStats[1]) - strength); stamina -= stamina / 7;
                                    Enemy(true); if (a == true) {
                                        goto init;
                                    }
                                }
                                else {
                                    Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("----------------------------------------\r\nVocê não tem estamina suficiente!\r\n----------------------------------------\r\n\r\n");
                                    goto init1;
                                }
                            }
                            else {
                                if (stamina < int.Parse(weapons[numbBox1 - 1][2])) {
                                    Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("----------------------------------------\r\nVocê não tem estamina suficiente!\r\n----------------------------------------\r\n\r\n");
                                    goto init1;
                                }
                                else {
                                    Console.Write("----------------------------------------\r\nVocê usou [" + (weapons[numbBox1 - 1][0]) + "] no " + enemyStats[0] + ", o causou -" + weapons[numbBox1 - 1][1] + " de dano e você perdeu -" + weapons[numbBox1 - 1][2] + " de estamina!\r\n");
                                    enemyStats[1] = Convert.ToString((int.Parse(enemyStats[1]) - int.Parse(weapons[numbBox1 - 1][1])));
                                    stamina -= int.Parse(weapons[numbBox1 - 1][2]);
                                    weapons[numbBox1 - 1][3] = Convert.ToString(int.Parse(weapons[numbBox1 - 1][3]) - 1);
                                    if (weapons[numbBox1 - 1][3] == "0") { Console.Write("----------------------------------------\r\nVocê destruiu ["+weapons[numbBox1 - 1][0]+"]!!!\r\n----------------------------------------\r\n"); numbBox = numbBox1; Update("weapon"); }
                                    Enemy(true); if (a == true) { goto init; }
                                }
                            }
                        }
                        else {
                            WrongChoice(); goto init1;
                        }
                        break;
                    case 2:
                        Console.Clear(); Inventory(ConsoleColor.Red); goto init;
                    case 3:
                        numbBox = 0; Console.Clear();
                        if (stamina > staminaMax / 10) {
                            if (Confirm(ConsoleColor.Red, "stamina") == true) {
                                if (ale.Next(0, 101) <= 65) {
                                    Console.Clear();
                                    Console.Write("----------------------------------------\r\nVocê não conseguiu fugir e perdeu -" + (staminaMax / 7) + " de estamina!!!\r\n");
                                    stamina -= staminaMax / 7;
                                    Enemy(true); goto init;
                                }
                                else {
                                    Console.Clear(); Console.Write("----------------------------------------\r\nVocê conseguiu fugir da batalha! Porém perdeu -" + (staminaMax / 7) + " de estamina!\r\n----------------------------------------\r\n\r\n");
                                    stamina -= staminaMax / 7;
                                }
                            }
                            else {
                                Console.Clear(); goto init;
                            }
                        }
                        else {
                            Console.Clear(); Console.Write("----------------------------------------\r\nVocê não tem estamina suficiente para fugir da batalha!\r\n----------------------------------------\r\n\r\n"); goto init;
                        }
                        break;
                }
            }
        }
        private void Enemy(bool isMySift) {
            if (isMySift == false) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("----------------------------------------\r\nVocê encontrou um inimigo!!!\r\n----------------------------------------\r\n\r\n");
                numbBox = ale.Next(0, 101);
                if (numbBox <= 60) {
                    enemyStats[0] = "[Slime]"; enemyStats[1] = Convert.ToString(ale.Next(strength * 4, strength * 6)); enemyStats[2] = Convert.ToString(ale.Next(lifeMax / 14, lifeMax / 10));
                }
                else if (numbBox <= 95) {
                    enemyStats[0] = "[Lobo]"; enemyStats[1] = Convert.ToString(ale.Next(strength * 2, strength * 4)); enemyStats[2] = Convert.ToString(ale.Next(lifeMax / 9, lifeMax / 7));
                }
                else if (numbBox <= 98) {
                    enemyStats[0] = "[Lobo ALPHA]"; enemyStats[1] = Convert.ToString(ale.Next(strength * 10, strength * 14)); enemyStats[2] = Convert.ToString(ale.Next(lifeMax, lifeMax * 2));
                }
                else {
                    enemyStats[0] = "[Dragão]"; enemyStats[1] = Convert.ToString(lifeMax * 2); enemyStats[2] = Convert.ToString(ale.Next(lifeMax/3));
                }
            }
            else {
                if (int.Parse(enemyStats[1]) <= 0) {
                    numbBox = ale.Next(levelMax / 10, 1 + levelMax / 5);
                    levelProgress += numbBox; a = false; numbBox1 = ale.Next(levelMax / 4, levelMax / 2);
                    Console.Write("você venceu o " + enemyStats[0] + ", recebeu +" + numbBox + " de experiência e +" + numbBox1 + " de estamina!!\r\n----------------------------------------\r\n\r\n");
                    LevelUp();
                }
                else {
                    life -= int.Parse(enemyStats[2]);
                    Console.Write("----------------------------------------\r\nVocê tomou -" + enemyStats[2] + " de vida!\r\n----------------------------------------\r\n\r\n");
                    a = true;
                }
            }
        }
        private void Weapons() {
        init2:
            if (currentWeaponSlot != 0) {
            init1:
                Console.Write("----------------------------------------\r\nSuas armas: \r\n");
                for (int i = 0; i < currentWeaponSlot; i++) {
                    Console.Write(weapons[i][0]+"["+i + 1+"] = Dano= "+weapons[i][1]+" Estamina= -"+weapons[i][2]+" Durabilidade= "+weapons[i][3]+"/"+weapons[i][4]+"\r\n");
                }
            init:
                numbBox = CheckChoice(ConsoleColor.DarkCyan, "WeaponInventory");
                if (numbBox <= currentWeaponSlot & numbBox > 0) {
                    if (Confirm(ConsoleColor.DarkCyan, "weapon") == true) {
                        Update("weapon"); Console.Clear(); goto init2;
                    }
                    else { Console.Clear(); goto init1; }
                }
                else if (numbBox == currentWeaponSlot + 1) { Console.Clear(); }
                else {
                    WrongChoice(); goto init;
                }
            }
            else {
                Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("----------------------------------------\r\nVocê não possui nenhuma arma!\r\n----------------------------------------\r\n\r\n");
            }
        }
        private void Inventory(ConsoleColor cor) {
        init2: Console.ForegroundColor = cor;
            if (currentInventorySlot != 0) {
            init1:
                Console.Write("----------------------------------------\r\nSeu Inventário: \r\n");
                for (int i = 0; i < currentInventorySlot; i++) {
                    Console.Write(inventory[i][0]+"["+i + 1+"]= +"+inventory[i][1]+" Pontos\r\n");
                }
            init: numbBox = 0; numbBox1 = 0;
                Console.Write("----------------------------------------\r\nDigite o número do item para usa-lo ou voltar(" + (currentInventorySlot + 1) + ")!\r\n");
                numbBox = CheckChoice(cor, "inventory"); numbBox1 = numbBox;
                if (numbBox <= currentInventorySlot & numbBox > 0) {
                    if (Confirm(cor, "inventory") == true) {
                        Console.Clear(); numbBox = numbBox1; Update("inventory"); numbBox1 = 268; goto init2;
                    }
                    else { Console.Clear(); goto init1; }
                }
                else if (numbBox == currentInventorySlot + 1) { Console.Clear(); }
                else {
                    WrongChoice(); goto init;
                }
            }
            else {
                if (numbBox1 == 268) { numbBox1 = 0; Console.WriteLine(); }
                Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("----------------------------------------\r\nVocê não possui nenhum item!\r\n----------------------------------------\r\n\r\n");
            }
        }
        private void Status() {
            Console.Write("----------------------------------------\r\nSeu status: \r\nNivel = "+level+" ("+levelProgress+"/"+levelMax+")\r\nVida = "+life+"/"+lifeMax+"\r\nEstamina = "+stamina+"/"+staminaMax+"\r\nForça(Dano do soco) = "+strength);
        }
        private void LevelUp() {
            if (levelProgress >= levelMax) {
                level++;
                life = lifeMax += 10; stamina = staminaMax += 10; strength += 3; levelProgress -= levelMax;
                Console.Write("\r\nSeu novo status: \r\nNivel = "+level+" ("+levelProgress+"/"+levelMax+")\r\nVida = "+life+"/"+lifeMax+"\r\nEstamina = "+stamina+"/"+staminaMax+"\r\nForça(Dano do soco) = "+strength+"\r\n----------------------------------------\r\n\r\n");
            }
        }
        private void Update(string a) {
            if (a == "weapon") {
                weapons[numbBox - 1][0] = null;
                weapons[numbBox - 1][1] = null;
                weapons[numbBox - 1][2] = null;
                weapons[numbBox - 1][3] = null;
                weapons[numbBox - 1][4] = null;
                for (int i = 0; i < currentWeaponSlot - 1; i++) {
                    if (weapons[i][0] == null) {
                        weapons[i][0] = weapons[i + 1][0]; weapons[i + 1][0] = null;
                        weapons[i][1] = weapons[i + 1][1]; weapons[i + 1][1] = null;
                        weapons[i][2] = weapons[i + 1][2]; weapons[i + 1][2] = null;
                        weapons[i][3] = weapons[i + 1][3]; weapons[i + 1][3] = null;
                        weapons[i][4] = weapons[i + 1][4]; weapons[i + 1][4] = null;
                    }
                }
                currentWeaponSlot--;
            }
            else {
                if (inventory[numbBox - 1][0] == "Poção de Vida") {
                    Console.Write("----------------------------------------\r\nVocê tomou uma [Poção de Vida] e recuperou +" + inventory[numbBox - 1][1] + " de vida!\r\n----------------------------------------\r\n\r\n"); life += int.Parse(inventory[numbBox - 1][1]);
                }
                else if (inventory[numbBox - 1][0] == "Super Poção de Vida") {
                    Console.Write("----------------------------------------\r\nVocê tomou uma [Super Poção de Vida] e recuperou +" + inventory[numbBox - 1][1] + " de vida!\r\n----------------------------------------\r\n\r\n"); life += int.Parse(inventory[numbBox - 1][1]); ;
                }
                else if (inventory[numbBox - 1][0] == "Poção de Estamina") {
                    Console.Write("----------------------------------------\r\nVocê tomou uma [Poção de Estamina] e recuperou +" + inventory[numbBox - 1][1] + " de estamina!\r\n----------------------------------------\r\n\r\n"); stamina += int.Parse(inventory[numbBox - 1][1]); ;
                }
                else if (inventory[numbBox - 1][0] == "Super Poção de Estamina") {
                    Console.Write("----------------------------------------\r\nVocê tomou uma [Super Poção de Estamina] e recuperou +" + inventory[numbBox - 1][1] + " de estamina!\r\n----------------------------------------\r\n\r\n"); stamina += int.Parse(inventory[numbBox - 1][1]); ;
                }
                if (stamina > staminaMax) { stamina = staminaMax; }
                if (life > lifeMax) { life = lifeMax; }
                inventory[numbBox - 1][0] = null;
                inventory[numbBox - 1][1] = null;
                for (int i = 0; i < currentInventorySlot - 1; i++) {
                    if (inventory[i][0] == null) {
                        inventory[i][0] = inventory[i + 1][0]; inventory[i + 1][0] = null;
                        inventory[i][1] = inventory[i + 1][1]; inventory[i + 1][1] = null;
                    }
                }
                currentInventorySlot--;
            }
        }
        private bool Confirm(ConsoleColor cor, string text) {
        init:
            Console.ForegroundColor = cor;
            if (text.Equals("stamina") & numbBox < 1) {
                Console.Write("----------------------------------------\r\nIsso ira lhe custar -" + (staminaMax / 7) + " de estamina\r\n");
                Console.Write("Você tem certeza que deseja realizar esta ação? sim(1) não(2)\r\n");
            }
            else if (text.Equals("weapon")) {
                Console.Write("Você tem certeza que deseja realizar esta ação? sim(1) não(2)\r\n");
            }

            switch (CheckChoice(cor, text)) {
                default:
                    numbBox1 = 665; WrongChoice(); goto init;
                case 1:
                    return true;
                case 2:
                    return false;
            }
        }
        private int CheckChoice(ConsoleColor cor, string text) {
        init:
            Console.ForegroundColor = cor; if (debugMode == true) { Console.Write("MODO DEBUG ATIVADO!\r\n"); }
            if (text.Equals("noite")) {
                Console.Write("----------------------------------------\r\n" + dayCycle + " " + dayProgress + "(" + currentTime + "/" + timeMax + ")\r\nProcurar por alguma coisa(1)\r\nVer Armas(2)\r\nAbrir Inventário(3)\r\nVer Status(4)\r\nDormir(5)\r\nSobre o software(6)\r\nSair(7)\r\n");
            }
            else if (text.Equals("dia")) {
                Console.Write("----------------------------------------\r\n" + dayCycle + " " + dayProgress + "(" + currentTime + "/" + timeMax + ")\r\nProcurar por alguma coisa(1)\r\nVer armas(2)\r\nAbrir Inventário(3)\r\nVer Status(4)\r\nSobre o software(5)\r\nSair(6)\r\n");
            }
            else if (text.Equals("battle")) {
                Status(); Console.Write("\r\n----------------------------------------\r\nStatus do inimigo:\r\nNome = " + enemyStats[0] + "\r\nVida = " + enemyStats[1] + "\r\nDano = " + enemyStats[2] + "\r\n----------------------------------------\r\n\r\n----------------------------------------\r\nEstá na sua vez!!! Faça a sua escolha: \r\nAtacar(1)\r\nAbrir Inventário(2)\r\nTentar fugir(3)\r\n");
            }
            else if (text.Equals("battleActionChoice")) {
                Console.Write("----------------------------------------\r\nAções: \r\n");
                for (int i = 0; i < currentWeaponSlot; i++) {
                    Console.Write(weapons[i][0]+"["+i + 1+"]= Dano = "+weapons[i][1]+" Estamina = -"+weapons[i][2]+" Durabilidade = "+weapons[i][3]+"/"+weapons[i][4]+"\r\n");
                }
                Console.Write("Soco["+(currentWeaponSlot + 1)+"]= Dano = "+strength+" Estamina = -"+stamina / 7+"\r\nVoltar["+(currentWeaponSlot + 2)+"]\r\n");
            }
            else if (text.Equals("WeaponInventory")) {
                Console.Write("----------------------------------------\r\nDigite o número da arma para joga-la fora ou voltar(" + (currentWeaponSlot + 1) + ")!\r\n");
            }
            else if (numbBox >= 1 & text.Equals("stamina")) {
                Console.Write("----------------------------------------\r\nIsso ira lhe custar -" + (staminaMax / 7) + " de estamina\r\n");
                Console.Write("Você tem certeza que deseja realizar esta ação? sim(1) não(2)\r\n");
            }
            else if (text.Equals("inventory") & numbBox1 >= 1) {
                if (numbBox1 == 666) { Console.Write("----------------------------------------\r\n"); }
                Console.Write("Você tem certeza que deseja usar este item? sim(1) não(2)\r\n");
            }
            Console.Write("Sua escolha: ");
            try {
                choice = int.Parse(Console.ReadLine()); Console.Write("----------------------------------------\r\n"); return choice;
            }
            catch {
                WrongChoice(); numbBox1 = 666; numbBox++; goto init;
            }
        }
        private void WrongChoice() {
            Console.Clear(); Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("----------------------------------------\r\nDigite uma opção válida!\r\n----------------------------------------\r\n\r\n");
        }
        private void DayCycle(bool slept) {
            if (slept.Equals(true)) {
                dayCycle = "dia";
                timeMax += 5;
                dayProgress++;
                currentTime = 1;
            }
            else {
                if (currentTime > timeMax) {
                    if (dayCycle == "dia") {
                        dayCycle = "noite";
                    }
                    else {
                        dayProgress++;
                        dayCycle = "dia";
                        timeMax += 5;
                    }
                    currentTime = 1;
                }
            }
        }
        private bool StaminaRecover() {
            for (int i = 0; i <= currentInventorySlot; i++) {
                if (inventory[i][0] == "Poção de Estamina" || inventory[i][0] == "Super Poção de Estamina") {
                    i = currentInventorySlot + 1; return true;
                }
            }
            return false;
        }
        private void Debug() {
            debugMode = true;
            for (int i = 0; i < 351; i++) {
                levelProgress = levelMax; LevelUp();
                if (i == 350) {
                    Console.Write("----------------------------------------\r\nVocê achou a [Excalibur], de uma checada nessa arma lendária em \"Ver Armas\"!\r\n----------------------------------------\r\n\r\n");
                    weapons[currentWeaponSlot][0] = "Excalibur"; weapons[currentWeaponSlot][1] = Convert.ToString(ale.Next(strength * 8, strength * 10));
                    weapons[currentWeaponSlot][2] = Convert.ToString(staminaMax / 2); weapons[currentWeaponSlot][3] = "1";
                    weapons[currentWeaponSlot][4] = "1"; currentWeaponSlot++;
                }
                if (i > 345) {
                    Console.Write("----------------------------------------\r\nVocê achou uma [Super Poção de Vida] que recupera " + (lifeMax / 4) + " de vida!\r\n----------------------------------------\r\n\r\n");
                    inventory[currentInventorySlot][0] = "Super Poção de Vida";
                    inventory[currentInventorySlot][1] = Convert.ToString(lifeMax / 4); currentInventorySlot++;
                }
                if (i > 345) {
                    Console.Write("----------------------------------------\r\nVocê achou uma [Super Poção de Estamina] que recupera " + staminaMax + " de estamina!\r\n----------------------------------------\r\n\r\n");
                    inventory[currentInventorySlot][0] = "Super Poção de Estamina";
                    inventory[currentInventorySlot][1] = Convert.ToString(staminaMax); currentInventorySlot++;
                }
            }
            Console.Clear();
        }
        static void Main(string[] args) {
            main obj = new main();
            obj.Start();
        }
    }
}