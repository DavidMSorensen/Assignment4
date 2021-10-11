package main;

namespace openClosed
{
    public class Tool{
        public void use(){}
    }


    public class Hammer : Tool{
    }

    public class Screwdriver : Tool{
    }

    static void Main(string[] args){
        Tool[] tools = {new Hammer(), new Screwdriver()};
        
        foreach(Tool t in tools){
                t.use();
        }
    }
}