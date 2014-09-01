package com.amos.thrift;

import java.nio.ByteBuffer;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.List;
import java.util.Map;

import org.apache.thrift.TException;
import org.apache.thrift.protocol.TBinaryProtocol;
import org.apache.thrift.protocol.TProtocol;
import org.apache.thrift.transport.TSocket;
import org.apache.thrift.transport.TTransport;
import org.apache.thrift.transport.TTransportException;

/**
 * Created by amosli on 14-8-12.
 */
public class BlogClient {

	public static final String SERVER_IP = "localhost";
	public static final int SERVER_PORT = 7911;
	public static final int TIMEOUT = 3000000;

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		BlogClient client = new BlogClient();
		client.startClient("amosli");

	}

	/**
	 * @param userName
	 */
	public void startClient(String userName) {
		TTransport transport = null;
		try {
			transport = new TSocket(SERVER_IP, SERVER_PORT, TIMEOUT);
			// 协议要和服务端一致
			TProtocol protocol = new TBinaryProtocol(transport);
			// TProtocol protocol = new TCompactProtocol(transport);
			// TProtocol protocol = new TJSONProtocol(transport);
			ThriftCase.Client client = new ThriftCase.Client(protocol);

			transport.open();
			
			//case 1
			client.testCase1(1, 2, "3");

			//case 2
			Map<String, String> num1 = new HashMap<String, String>();
			num1.put("username", "amosli");
			num1.put("address", "shanghai");
			client.testCase2(num1);

			//case 3
			client.testCase3();


			//case 4
			List<Blog> list = new ArrayList<Blog>();
			ByteBuffer content = ByteBuffer.allocate(30);
			content.put("this is content java client".getBytes());

			Map<String, String> props = new Hashtable<String, String>();
			props.put("one", "1");
			props.put("two", "2");
			props.put("three", "3");

			list.add(new Blog("topic1 is rpc", content, System.currentTimeMillis(), "001", "192.168.0.11", props));
			list.add(new Blog("topic2 is rpc too!", content, System.currentTimeMillis(), "002", "192.168.0.12", props));

			client.testCase4(list);

			System.out.println("blog client stop ....");
		} catch (TTransportException e) {
			e.printStackTrace();
		} catch (TException e) {
			e.printStackTrace();
		} finally {
			if (null != transport) {
				transport.close();
			}
		}
	}

}