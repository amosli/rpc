struct Blog {
    1: string topic 
    2: binary content 
    3: i64    createdTime 
    4: string id 
    5: string ipAddress 
    6: map<string,string> props 
  }
service ThriftCase {
    i32 testCase1(1:i32 num1, 2:i32 num2, 3:string  num3)
    list<string> testCase2(1:map<string,string>  num1)
    void testCase3()
    void testCase4(1:list<Blog> blog)  
}