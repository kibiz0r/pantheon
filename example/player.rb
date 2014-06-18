class Player < Domain
  proxy_accessor :paddle

  def log(str)
    puts "Player domain: #{str}"
  end

  command :join do |player_number|
    request.join player_number
  end

  capture :player_joined do |player_number|
    log "Player #{player_number} joined"
  end

  command :move_up do
    request(paddle).move_up
    # Requesting the move will invoke the Paddle's move_up command,
    # and when it is finalized by the Pong domain, the Player domain will
    # apply any produces deltas, processing any emitted events, which
    # may include materializing proxies.
  end

  capture(paddle).moved do
  end
end
